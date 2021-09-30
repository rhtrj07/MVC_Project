using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models;

namespace MVCProject.Repositories
{
    public interface IUsersRepository
    {
        List<EmployeeDetails> GetUsersByEmailAndPassword(string Email, string Password);
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

    }
}