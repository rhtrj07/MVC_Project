using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.ViewModels
{
    public class HRProfileViewModel
    {
        public int? EmployeeID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string PasswordHash { get; set; }

        public long Mobile { get; set; }

        public string Email { get; set; }

        public string Department { get; set; }

        public string Role { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string ImageURL { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public int? ProjManagerID { get; set; }

        public string PMFName { get; set; }

        public string PMLName { get; set; }
    }
}