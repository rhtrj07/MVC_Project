using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCProject.Models
{
    public class HTMLHelperDropDownModels
    {
        public enum Gender
        {
            Male,
            Female
        }
        
        public enum Department
        {
            Sales,
            Production,
            Developer,
            Resource,
            Marketing,
            Accounting,
            Administration,
            Purchasing,
            Financial
        }
        
        public enum Role
        {
            Project_Manager,
            Employee,
            HR
            
        }
        
        public enum LeaveType
        {  
            Sick_Leave ,
            Casual_Leave ,
            Unpaid_Leave ,
            Paid_Leave 
            
        }
    }
}