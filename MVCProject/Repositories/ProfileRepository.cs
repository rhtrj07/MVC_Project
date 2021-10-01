using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models;

namespace MVCProject.Repositories
{
    public interface IProfileRepository
    {
        List<EmployeeDetails> GetProfileByEmployeeID(int ProfileID);
    }

    public class ProfileRepository : IProfileRepository
    {
        EmployeeDBContext db;

        public ProfileRepository()
        {
            db = new EmployeeDBContext();
        }

        public List<EmployeeDetails> GetProfileByEmployeeID (int ProfileID)
        {
            List<EmployeeDetails> ed = db.employeeDetails.Where(temp => temp.EmployeeID == ProfileID).ToList();
            return ed;

        }


    }
}