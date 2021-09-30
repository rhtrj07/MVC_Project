using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVCProject.Models
{
    public class LeaveRequest
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveRequestID { get; set; }
        [Display(Name = "EmployeeID")]
        public int EmployeeID { get; set; }
        public Nullable <int> ProjManagerID { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string Description { get; set; }
        public string LeaveStatus { get; set; }

        //-------------------------------------------
        
        [ForeignKey("EmployeeID")]
        public virtual EmployeeDetails EmpIDEmployee { get; set; }

        //-------------------------------------------

        public virtual EmployeeDetails EmployeeDetails { get; set; }
        //-------------------------------------------

    }
}