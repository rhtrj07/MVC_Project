﻿using System;
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

        public long Mobile { get; set; }

        public string Department { get; set; }

        public string Role { get; set; }

        
        public string Email { get; set; }

        [Required]
        public DateTime DOB { get; set; }

        [Required]
        public string Gender { get; set; }

        public string ImageURL { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Location { get; set; }


        public int ProjManagerID { get; set; }

        public string PMFName { get; set; }

        public string PMLName { get; set; }

    }
}