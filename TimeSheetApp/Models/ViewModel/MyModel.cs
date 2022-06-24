using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetApp.Models.ViewModel
{
    public class MyModel
    {
        public string Username { get; set; }
        
        public string Reason { get; set; }
        public string Message { get; set; }
    }
}
