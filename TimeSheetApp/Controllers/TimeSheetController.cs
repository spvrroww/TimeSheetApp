using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Models;
using TimeSheetApp.Models.ViewModel;
using TimeSheetApp.Services.IServices;

namespace TimeSheetApp.Controllers
{
    public class TimeSheetController : Controller
    {
        private readonly ITimeSheetService _timeSheetService;
        private  Stopwatch timer = new Stopwatch();
        private bool clockedIn;
        
       
        public TimeSheetController(ITimeSheetService timeSheetService)
        {
            _timeSheetService = timeSheetService;
        }

        public IActionResult Panel(string username)
        {
            byte[] check;
             HttpContext.Session.TryGetValue("ssrunning",out check); 
            if(check is null)
            {
                HttpContext.Session.SetString("ssrunning", "false");
            }
            
            MyModel model = new MyModel { Username = username };
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> ClockIn(MyModel model)
        {
            clockedIn = bool.Parse(HttpContext.Session.GetString("ssrunning"));
            var sheet = await _timeSheetService.GetLastTimeSheet(model.Username);
            var clockInTime = new ClockInClockOutTime { ClockInTime = DateTime.Now, Reason = model.Reason };

            if (!clockedIn)
            {
                

                if (sheet!= null && DateTime.Now.Date == sheet.Day.Date)
                {
                    timer.Start();
                    List<ClockInClockOutTime> AllClockInClockOutTimes = sheet.ClockInClockOutTimes.ToList();
                    AllClockInClockOutTimes.Add(clockInTime);
                    sheet.ElapsedTime = timer.Elapsed;
                    sheet.ClockInClockOutTimes = AllClockInClockOutTimes;
                    var updatedSheet = await _timeSheetService.Update(sheet.Id, sheet);
                    HttpContext.Session.SetString("ssrunning", "true");
                    return RedirectToAction("Dashboard", "Home", new { id = updatedSheet.Username });
                    
                }
                else if (sheet==null || DateTime.Now.Date > sheet.Day.Date)
                {
                    timer.Restart();
                    var newsheet = new TimeSheet { Username = model.Username, ElapsedTime = timer.Elapsed, Day = DateTime.Now, ClockInClockOutTimes = new List<ClockInClockOutTime>() { new ClockInClockOutTime { ClockInTime = DateTime.Now, Reason = model.Reason } } };
                    var addedsheet = await _timeSheetService.Create(newsheet);
                    HttpContext.Session.SetString("ssrunning", "true");
                    return RedirectToAction("Dashboard", "Home", new{id = addedsheet.Username});

                }
                else
                {
                    return RedirectToAction("Dashboard", "Home", new { id =sheet.Username });
                }

            }
            else
            {
                string message = "You are clocked in, Please clock out first";
                return View("Panel", new MyModel { Message = message });

            }
            
        }
        [HttpPost]
        public async Task<IActionResult> ClockOut(MyModel model)
        {
            clockedIn = bool.Parse(HttpContext.Session.GetString("ssrunning"));
            var sheet = await _timeSheetService.GetLastTimeSheet(model.Username);
            var clockOutTime = new ClockInClockOutTime { ClockOutTime = DateTime.Now, Reason = model.Reason };
            if (clockedIn) 
            {
                
                
            timer.Stop();
            if (DateTime.Now.Date == sheet.Day.Date)
            {
                
                List<ClockInClockOutTime> AllClockInClockOutTimes = sheet.ClockInClockOutTimes.ToList();
                sheet.ElapsedTime = timer.Elapsed;
                  AllClockInClockOutTimes.Add(clockOutTime);
                    sheet.ClockInClockOutTimes = AllClockInClockOutTimes;
                var updatedSheet = await _timeSheetService.Update(sheet.Id, sheet);
                    HttpContext.Session.SetString("ssrunning", "false");
                    return RedirectToAction("Dashboard", "Home",new { id = updatedSheet.Username });
            }
            else if (DateTime.Now.Date > sheet.Day.Date)
            {
                var newsheet = new TimeSheet { Username = model.Username, ElapsedTime = timer.Elapsed, Day = DateTime.Now, ClockInClockOutTimes = new List<ClockInClockOutTime>() { new ClockInClockOutTime { ClockOutTime = DateTime.Now, Reason = model.Reason } } };
                var addedsheet = await _timeSheetService.Create(newsheet);
                    HttpContext.Session.SetString("ssrunning", "false");
                    return RedirectToAction("Dashboard", "Home", new { id = addedsheet.Username });
            }
            else
            {
                return RedirectToAction("Dashboard", "Home", new { id = sheet.Username});
            }
            }
            else
            {
                string message = "You are still clocked out, Please clock in first";
                return View("Panel", new MyModel { Message = message});
            }
            
        }
    }
}
