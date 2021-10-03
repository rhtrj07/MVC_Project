using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.ViewModels
{
    public class UserViewModel
    {
        public int EmployeeID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Mobile { get; set; }
        public string Roll { get; set; }
        public string Designation { get; set; }
        public string ImageURL { get; set; }
    }
}