using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models;
using MVCProject.ViewModels;

namespace MVCProject.Repositories
{
    public interface IUsersRepository
    {
        List<EmployeeDetails> GetUsersByEmailAndPassword(string Email, string Password);
        List<EmployeeDetails> GetManagerID(int id);
        bool CheckIfDeleteIsAllowed(int id);
    }


    public class UsersRepository : IUsersRepository
    {
        EmployeeDBContext db;

        public UsersRepository()
        {
            db = new EmployeeDBContext();
        }

        public List<EmployeeDetails> GetUsersByEmailAndPassword(string Email, string PasswordHash)
        {
            List<EmployeeDetails> us = db.employeeDetails.Where(temp => temp.Email == Email && temp.PasswordHash == PasswordHash).ToList();
            return us;
        }

        public List<EmployeeDetails> GetManagerID(int id)
        {
            List<EmployeeDetails> us  = db.employeeDetails.Where(temp => temp.EmployeeID == id ).ToList();
            return us;
        }

        public bool CheckIfDeleteIsAllowed(int id)
        {
            List<EmployeeDetails> us = db.employeeDetails.Where(temp => temp.ProjManagerID == id).ToList();

            if (us.Count == 0)
                return true;
            else
                return false;
        }

    }
}