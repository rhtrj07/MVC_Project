using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.ViewModels
{
    public class HRProfileViewModel
    {
        public int? EmployeeID { get; set; }

        [Required(ErrorMessage = "First Name can't be blank")]
        public string FName { get; set; }

        [Required(ErrorMessage = "Last Name can't be blank")]
        public string LName { get; set; }

        
        public string PasswordHash { get; set; }

        [Required(ErrorMessage = "Mobie number can't be blank")]
        [RegularExpression(@"(^[0-9]{10}$)", ErrorMessage = "Mobile number is not valid")]
        public long Mobile { get; set; }

        [Required]
        [RegularExpression(@"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Role { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Location { get; set; }

        public string ImageURL { get; set; }

        public int? ProjManagerID { get; set; }

        public string PMFName { get; set; }

        public string PMLName { get; set; }
    }
}