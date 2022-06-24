﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetApp.Models.ViewModel
{
    public class UserAuthenticationRequest
    {
        [Required(ErrorMessage ="Username is Required")]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Password is required")]
        public string Password { get; set; }

    }
}
