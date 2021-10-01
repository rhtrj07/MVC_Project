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
        public string Name { get; set; }
        [StringLength(50)]
        public string PasswordHash { get; set; }
        public Nullable <long> Mobile { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }

        [Display(Name = "ProjManagerID")]
        public Nullable<int> ProjManagerID { get; set; }

        public string Address { get; set; }
        public string Location { get; set; }

        [ForeignKey("ProjManagerID")]
        public virtual EmployeeDetails ProjIDEmployee { get; set; }

<<<<<<< Updated upstream
        public virtual ICollection<LeaveRequest> LeaveRequests { get; set; }
=======
    }
}
>>>>>>> Stashed changes


    }
}