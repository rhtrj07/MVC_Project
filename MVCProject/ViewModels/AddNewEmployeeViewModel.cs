using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.ViewModels
{
    public class AddNewEmployeeViewModel
    {
        [Required]
        public string FName { get; set; }

        [Required]
        public string LName { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public long Mobile { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Role { get; set; }


        public int? ProjManagerID { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string ImageURL { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }

    }
}