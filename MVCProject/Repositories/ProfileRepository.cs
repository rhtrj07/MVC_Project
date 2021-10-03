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
        void UpdateEmployeeDetailsFromEmployee(EmployeeDetails u );
    }

    public class ProfileRepository : IProfileRepository
    {
        EmployeeDBContext db;

        public ProfileRepository()
        {
            db = new EmployeeDBContext();
        }

        public List<EmployeeDetails> GetProfileByEmployeeID(int ProfileID)
        {
            List<EmployeeDetails> ed = db.employeeDetails.Where(temp => temp.EmployeeID == ProfileID).ToList();
            return ed;

        }

        public void UpdateEmployeeDetailsFromEmployee(EmployeeDetails u )
        {
            EmployeeDetails us = db.employeeDetails.Where(temp => temp.EmployeeID == u.EmployeeID).FirstOrDefault();
            if (us != null)
            {
                us.Mobile = u.Mobile;
                us.DOB = u.DOB;
                us.Gender = u.Gender;
                us.ImageURL = u.ImageURL;
                us.Address = u.Address;
                us.Location = u.Location;
                db.SaveChanges();
            }
        }


    }
}