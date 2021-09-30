using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MVCProject.Models
{
    public class EmployeeDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        [StringLength(100)]
        public string PasswordHash { get; set; }
        public Nullable <long> Mobile { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Roll { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public string Gender { get; set; }
        [StringLength(50)]
        public string ImageURL { get; set; }

        [Display(Name = "ProjManagerID")]
        public Nullable<int> ProjManagerID { get; set; }

        public string Address { get; set; }
        public string Location { get; set; }

        [ForeignKey("ProjManagerID")]
        public virtual EmployeeDetails ProjIDEmployee { get; set; }

        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}

