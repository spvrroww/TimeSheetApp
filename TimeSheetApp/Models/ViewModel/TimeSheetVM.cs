using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetApp.Models.ViewModel
{
    public class TimeSheetVM
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Day { get; set; }
        public string ElapsedTime { get; set; }
        public List<ClockInTimesVm> ClockInTimes { get; set; }
        public List<ClockOutTimesVM> ClockOutTimes { get; set; }
        
    }
}
