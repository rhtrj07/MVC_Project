using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.ViewModels
{
    public class LeaveViewModel
    {
        
        //public int LeaveRequestID { get; set; }
        
        public int LeaveRequestID { get; set; }
        public int EmployeeID { get; set; }
        public int ProjManagerID { get; set; }

        [Required]
        public DateTime FromDate { get; set; }
        
        [Required] 
        public DateTime ToDate { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public string LeaveType { get; set; }

        public string LeaveStatus { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }


    }
}