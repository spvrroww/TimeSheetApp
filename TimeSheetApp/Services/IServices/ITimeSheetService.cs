using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheetApp.Models;

namespace TimeSheetApp.Services.IServices
{
    public interface ITimeSheetService
    {
        public Task<TimeSheet> GetTimeSheet(int id);
        public Task<IEnumerable<TimeSheet>> GetSheetsByUsername(string id);
        public Task<TimeSheet> Create(TimeSheet timeSheet);
        public Task<TimeSheet> Update(int id, TimeSheet timeSheet);
        public Task<int> Delete(int id);
        public Task<TimeSheet> GetLastTimeSheet(string userId);
        
        
    }
}
