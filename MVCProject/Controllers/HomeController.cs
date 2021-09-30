using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.Models;

namespace MVCProject.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //EmployeeDBContext db = new EmployeeDBContext();
            //List<EmployeeDetails> employee = db.employeeDetails.Where(temp => temp.FName.Contains("Niha")).ToList();
            //return View(employee);
            return View();

        }

        public ActionResult EditProfile()
        {
            return View();
        }
    }
}

