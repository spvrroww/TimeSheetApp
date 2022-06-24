using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetApp.Models.ViewModel
{
    public class AuthenticationResponseModel
    {
       
        public string username { get; set; }
        public bool IsAuthSuccessful { get; set; }
    }
}
