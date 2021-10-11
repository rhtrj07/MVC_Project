using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.ViewModels
{
    public class EmailSendViewModel
    {
        public int EmployeeID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string Department { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }
        
        public string LeaveStatus { get; set; }


    }
}