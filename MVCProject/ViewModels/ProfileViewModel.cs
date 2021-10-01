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
        
        public string PasswordHash { get; set; }
     
        public long Mobile { get; set; }
 
        public string Email { get; set; }
  
        public string Designation { get; set; }
      
        public string Roll { get; set; }
        public DateTime DOB { get; set; }
        public string Gender { get; set; }
        public string ImageURL { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
    }
}