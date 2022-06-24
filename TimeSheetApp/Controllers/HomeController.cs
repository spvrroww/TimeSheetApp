using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Models;
using TimeSheetApp.Models.ViewModel;
using TimeSheetApp.Services.IServices;

namespace TimeSheetApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITimeSheetService _timeSheetService;
        private readonly SignInManager<IdentityUser> _signInManager;
        public HomeController(ITimeSheetService timeSheetService, SignInManager<IdentityUser>signInManager)
        {
            _timeSheetService = timeSheetService;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return RedirectToAction("DashBoard", new { id = HttpContext.Session.GetString("ssuserid") });
            }
            
            return View();
        }

        public async Task<IActionResult> DashBoard(string id)
        {
            var sheets = await  _timeSheetService.GetSheetsByUsername(id);
            List<TimeSheetVM> sheetVM = new List<TimeSheetVM>();
            foreach(var sheet in sheets)
            {
                sheetVM.Add(new TimeSheetVM { Id = sheet.Id, Day = sheet.Day, ElapsedTime = $"{sheet.ElapsedTime.Hours}:{sheet.ElapsedTime.Minutes}:{sheet.ElapsedTime.Seconds}", UserId = sheet.Username,
                ClockInTimes = sheet.ClockInClockOutTimes.Select(x=> new ClockInTimesVm { ClockinTime = x.ClockInTime , Reason=x.Reason}).ToList(), 
                    ClockOutTimes = sheet.ClockInClockOutTimes.Select(x => new ClockOutTimesVM{ ClockOutTime = x.ClockOutTime, Reason = x.Reason }).ToList(),
                });
                
            }
            
            return View(sheetVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var sheet = await _timeSheetService.GetTimeSheet(id);

            TimeSheetVM timeSheetVM = new TimeSheetVM {
                Id = sheet.Id,
                UserId = sheet.Username,
                Day = sheet.Day,
                ElapsedTime = $"{sheet.ElapsedTime.Hours}:{sheet.ElapsedTime.Minutes};{sheet.ElapsedTime.Seconds}",
                ClockInTimes = sheet.ClockInClockOutTimes.Select(x=> new ClockInTimesVm{ ClockinTime = x.ClockInTime, Reason = x.Reason}).ToList(),
                ClockOutTimes = sheet.ClockInClockOutTimes.Select(x => new ClockOutTimesVM { ClockOutTime = x.ClockOutTime, Reason = x.Reason }).ToList()
            };
            
            return View(timeSheetVM);
        }



    }
}
