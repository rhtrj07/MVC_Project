using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVCProject.Models
{
    public class LeaveRequestName
    {
        public int LeaveRequestID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Description { get; set; }
        public string LeaveType { get; set; }
        public string LeaveStatus { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }

    }


}