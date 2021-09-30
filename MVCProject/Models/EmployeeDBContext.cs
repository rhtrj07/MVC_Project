using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace MVCProject.Models
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext() : base("EmployeeDetailsDbContext")
        {
        }
        public DbSet<EmployeeDetails> employeeDetails{ get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        
    }
}      
