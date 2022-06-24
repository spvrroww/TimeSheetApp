using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetApp.Models
{
    public class TimeSheet
    {
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime Day { get; set; } = DateTime.Now;
        public TimeSpan ElapsedTime { get; set; }
        public  IEnumerable<ClockInClockOutTime> ClockInClockOutTimes { get; set; }
    }
}
