using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Models;
using TimeSheetApp.Services.IServices;

namespace TimeSheetApp.Services
{
    public class TimeSheetService:ITimeSheetService
    {
        private readonly ApplicationDbContext _db;
        public TimeSheetService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<TimeSheet> GetTimeSheet(int id)
        {
            var sheet = await _db.TimeSheet.Include(x=>x.ClockInClockOutTimes).FirstOrDefaultAsync(x => x.Id == id);
            return sheet;
        }
        public async Task<IEnumerable<TimeSheet>> GetSheetsByUsername(string id)
        {
            var sheet = await _db.TimeSheet.Where(x => x.Username == id).Include(x=> x.ClockInClockOutTimes).ToListAsync();
            return sheet;
        }
        public async Task<TimeSheet> Create(TimeSheet timeSheet)
        {
            try
            {
                var sheet = await _db.TimeSheet.AddAsync(timeSheet);
                await _db.SaveChangesAsync();
                return sheet.Entity;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<TimeSheet> Update(int id, TimeSheet timeSheet)
        {
            try
            {
                var sheet = await _db.TimeSheet.FirstOrDefaultAsync(x=> x.Id==id);
                sheet.ClockInClockOutTimes = timeSheet.ClockInClockOutTimes;
                sheet.Day = timeSheet.Day;
                


                var updatedSheet = _db.TimeSheet.Update(sheet);
                await _db.SaveChangesAsync();
                return updatedSheet.Entity;
                
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<int> Delete(int id)
        {
            var sheet = await _db.TimeSheet.FirstOrDefaultAsync(x => x.Id == id);
             _db.TimeSheet.Remove(sheet);
            return await _db.SaveChangesAsync();


        }

        public async Task<TimeSheet> GetLastTimeSheet(string id)
        {
            if (_db.TimeSheet.Any())
            {
                var sheet =  _db.TimeSheet.Where(x => x.Username == id).Include(x=>x.ClockInClockOutTimes).ToList().GroupBy(x => x.Id).Select(grp => grp.OrderByDescending(x=> x.Day.Day).First()).ToList();
                return sheet.First();
            }
            else
            {
                return null;
            }
            
        }
    }
}
