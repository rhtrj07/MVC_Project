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
        List<EmployeeDetailsName> GetProfile();
        List<ProjectManagerList> GetProjectManagerList();
        List<EmployeeDetailsName> GetProfileBySearch(string role, string name);
        void UpdateEmployeeDetailsFromEmployee(EmployeeDetails u );
        void UpdateEmployeeDetailsFromHR(EmployeeDetails u );
        void InsertIntoEmployee(EmployeeDetails u );
        void DeleteEmployeeByID(int id );
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
        
        public void UpdateEmployeeDetailsFromHR(EmployeeDetails u )
        {
            EmployeeDetails us = db.employeeDetails.Where(temp => temp.EmployeeID == u.EmployeeID).FirstOrDefault();
            if (us != null)
            {
                us.FName = u.FName;
                us.LName = u.LName;
                us.Role = u.Role;
                us.Department = u.Department;
                us.Email = u.Email;
                us.ProjManagerID = u.ProjManagerID;
                us.Mobile = u.Mobile;
                us.DOB = u.DOB;
                us.Gender = u.Gender;
                us.ImageURL = u.ImageURL;
                us.Address = u.Address;
                us.Location = u.Location;
                db.SaveChanges();
            }

            List<LeaveRequest> leaveRequests = db.LeaveRequests.Where(temp => temp.EmployeeID == u.EmployeeID).ToList();
            foreach(var item in leaveRequests)
            {
                item.ProjManagerID = u.ProjManagerID;
                db.SaveChanges();
            }

        }

        public List<EmployeeDetailsName> GetProfile()
        {
            List<EmployeeDetailsName> edn = new List<EmployeeDetailsName>();

            List<EmployeeDetails> qt = db.employeeDetails.ToList();

            foreach (var item in qt)
            {
                edn.Add(new EmployeeDetailsName
                {
                    EmployeeID = item.EmployeeID,
                    Location = item.Location,
                    DOB = item.DOB,
                    FName = item.FName,
                    LName = item.LName,
                    Mobile = item.Mobile,
                    Email = item.Email,
                    Department = item.Department,
                    Role = item.Role,
                    Gender = item.Gender,
                    ImageURL = item.ImageURL,
                    Address = item.Address,

                    PMFName = db.employeeDetails.Where(temp => temp.EmployeeID == item.ProjManagerID).Select(m => m.FName).ToList().FirstOrDefault(),
                    PMLName = db.employeeDetails.Where(temp => temp.EmployeeID == item.ProjManagerID).Select(m => m.LName).ToList().FirstOrDefault()
                });

            }
            return edn;


        }
        
        public List<EmployeeDetailsName> GetProfileBySearch(string role, string name)
        {
            List<EmployeeDetailsName> edn = new List<EmployeeDetailsName>();

            List<EmployeeDetails> qt = db.employeeDetails.Where(temp => temp.Role == role && (temp.FName.ToLower().Contains(name.ToLower()) || temp.LName.ToLower().Contains(name.ToLower()))).ToList();

            foreach (var item in qt)
            {
                edn.Add(new EmployeeDetailsName
                {
                    EmployeeID = item.EmployeeID,
                    Location = item.Location,
                    DOB = item.DOB,
                    FName = item.FName,
                    LName = item.LName,
                    Mobile = item.Mobile,
                    Email = item.Email,
                    Department = item.Department,
                    Role = item.Role,
                    Gender = item.Gender,
                    ImageURL = item.ImageURL,
                    Address = item.Address,

                    PMFName = db.employeeDetails.Where(temp => temp.EmployeeID == item.ProjManagerID).Select(m => m.FName).ToList().FirstOrDefault(),
                    PMLName = db.employeeDetails.Where(temp => temp.EmployeeID == item.ProjManagerID).Select(m => m.LName).ToList().FirstOrDefault()
                });

            }
            return edn;


        }

        public List<ProjectManagerList> GetProjectManagerList()
        {
            List<ProjectManagerList> ProjectManagerLists = new List<ProjectManagerList>();

            List<EmployeeDetails> employeeDetail = db.employeeDetails.Where(x => x.Role == "Project_Manager").ToList();

            ProjectManagerLists.Add(new ProjectManagerList
            {
                EmployeeID = null,
                FName = "No Project Manager"
               
            });

            foreach (var item in employeeDetail)
            {
                ProjectManagerLists.Add(new ProjectManagerList
                {
                    EmployeeID = item.EmployeeID,
                    FName = item.FName +" " +item.LName
                });

            }
            return ProjectManagerLists;
        }

        public void InsertIntoEmployee(EmployeeDetails u)
        {
            EmployeeDetails us = new EmployeeDetails();

            us.FName = u.FName;
            us.LName = u.LName;
            us.Role = u.Role;
            us.PasswordHash = u.PasswordHash;
            us.Department = u.Department;
            us.Email = u.Email;
            us.ProjManagerID = u.ProjManagerID;
            us.Mobile = u.Mobile;
            us.DOB = u.DOB;
            us.Gender = u.Gender;
            us.ImageURL = u.ImageURL;
            us.Address = u.Address;
            us.Location = u.Location;
            db.employeeDetails.Add(us);
            db.SaveChanges();

        }

        public void DeleteEmployeeByID(int id)
        {
            EmployeeDetails employee = db.employeeDetails.Where(x => x.EmployeeID == id).ToList().FirstOrDefault();

            db.employeeDetails.Remove(employee);
            try
            {
                db.SaveChanges();
            }
            catch
            {

            }
            
            
        }

    }
}