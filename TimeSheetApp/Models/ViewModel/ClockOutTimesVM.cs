using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetApp.Models.ViewModel
{
    public class ClockOutTimesVM
    {
        public DateTime ClockOutTime { get; set; }
        public string Reason { get; set; }
    }
}
