using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.ViewModels
{
    public class ProfileViewModel
    {

        public int EmployeeID { get; set; }

        public string FName { get; set; }

        public string LName { get; set; }

        public string Department { get; set; }

        public string Role { get; set; }

        public string Email { get; set; }

        public string ImageURL { get; set; }

        public int ProjManagerID { get; set; }

        public string PMFName { get; set; }

        public string PMLName { get; set; }


        [Required(ErrorMessage = "Mobie number can't be blank")]
        [RegularExpression(@"(^[0-9]{10}$)", ErrorMessage = "Mobile number is not valid")]
        public long Mobile { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Location { get; set; }

        

    }
}