using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetApp.Models
{
    public class ClockInClockOutTime
    {
        [Key]
        public int Id { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime ClockOutTime { get; set; }
        public string Reason { get; set; }
        public int SheetId { get; set; }
        [ForeignKey(nameof(SheetId))]
        public virtual TimeSheet TimeSheet { get; set; }

    }
}
