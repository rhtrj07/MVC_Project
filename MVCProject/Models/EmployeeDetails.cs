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
        public EmployeeDetails()
        {
            this.LeaveRequests = new HashSet<LeaveRequest>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeID { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        [StringLength(100)]
        public string PasswordHash { get; set; }
        public Nullable <long> Mobile { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Role { get; set; }
        public Nullable<DateTime> DOB { get; set; }
        public string Gender { get; set; }
        public string ImageURL { get; set; }

        [Display(Name = "ProjManagerID")]
        public Nullable<int> ProjManagerID { get; set; }

        public string Address { get; set; }
        public string Location { get; set; }

        public bool IsSpecialPermission { get; set; }

        [ForeignKey("ProjManagerID")]
        public virtual EmployeeDetails ProjIDEmployee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage","CA2227:CollectionPropertiesShouldBeRealOnly")]
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
    }
}

