using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetApp.Models.ViewModel
{
    public class UserRequestModel
    {
        [Required(ErrorMessage ="This field cannot be empty")]
        public string Username { get; set; }
        public string Role { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field cannot be empty")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This field cannot be empty")]
        [Compare("Password", ErrorMessage ="Passwords Dont match")]
        public string ConfirmPassword { get; set; }
    }
}
