using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheetApp.Common
{
    public static class SD
    {
        public  const string admin_Role = "Admin";
        public  const string employee_Role = "Employee";

        public static List<SelectListItem> GetRolesForDropDown()
        {
            return new List<SelectListItem>
            {
                new SelectListItem{Value = SD.admin_Role, Text= SD.admin_Role},
                new SelectListItem{Value = SD.employee_Role, Text = SD.employee_Role}
            }; 
        }
    }
}
