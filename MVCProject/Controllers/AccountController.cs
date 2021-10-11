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
        IUsersService UsersServices;

        public AccountController(IUsersService UsersServices)
        {
            this.UsersServices = UsersServices;
        }

        // GET: Account
        public ActionResult Login()
        {
            LoginViewModel LoginViewModels = new LoginViewModel();
            return View(LoginViewModels);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel LoginViewModels)
        {

            if (ModelState.IsValid)
            {
                UserViewModel uvm = this.UsersServices.GetUsersByEmailAndPassword(LoginViewModels.Email, LoginViewModels.Password);
                if (uvm != null)
                {
                    Session["CurrentUserID"] = uvm.EmployeeID;
                    Session["CurrentUserName"] = uvm.FName+ " " + uvm.LName;
                    Session["CurrentUserEmail"] = uvm.Email;
                    Session["CurrentUserPassword"] = uvm.Password;
                    Session["CurrentUserRole"] = uvm.Role;
                    Session["CurrentUserDepartment"] = uvm.Department;
                    Session["CurrentUserProfilePhoto"] = uvm.ImageURL;
                    Session["IsSpecialPermission"] = uvm.IsSpecialPermission;

                    return RedirectToAction("index", "Home");

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
            return View(LoginViewModels);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("index", "Home");
        }
    }

}