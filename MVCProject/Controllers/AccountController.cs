using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.ViewModels;
using MVCProject.ServiceLayer;

namespace MVCProject.Controllers
{
    public class AccountController : Controller
    {
        IUsersService us;

        public AccountController(IUsersService us)
        {
            this.us = us;
        }

        // GET: Account
        public ActionResult Login()
        {
            LoginViewModel lvm = new LoginViewModel();
            return View(lvm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel lvm)
        {

            if (ModelState.IsValid)
            {
                UserViewModel uvm = this.us.GetUsersByEmailAndPassword(lvm.Email, lvm.Password);
                if (uvm != null)
                {
                    Session["CurrentUserID"] = uvm.EmployeeID;
                    Session["CurrentUserName"] = uvm.FName+ " " + uvm.LName;
                    Session["CurrentUserEmail"] = uvm.Email;
                    Session["CurrentUserPassword"] = uvm.Password;
                    Session["CurrentUserRoll"] = uvm.Roll;
                    Session["CurrentUserDesignation"] = uvm.Designation;


                    return RedirectToAction("index", "Home");

                    //if (uvm.IsAdmin)
                    //{
                    //    return RedirectToRoute(new { area = "admin", controller = "AdminHome", action = "index" });
                    //}
                    //else
                    //{
                    //    return RedirectToAction("index", "Home");
                    //}
                }
                else
                {
                    ModelState.AddModelError("x", "invalid Email/Password");
                }

            }
            else
            {
                ModelState.AddModelError("x", "invalid Data");
            }
            return View(lvm);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("index", "Home");
        }
    }

}