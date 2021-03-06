using MVCProject.Models;
using MVCProject.ServiceLayer;
using MVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using MVCProject.Filter;

namespace MVCProject.Controllers
{
    public class ProfileController : Controller
    {
        IProfileService ProfileServices;

        public ProfileController(IProfileService ProfileServices)
        {
            this.ProfileServices = ProfileServices;
        }

        [AuthenticationFilter]
        [EmployeeAndManagerAuthorizationFilter]
        public ActionResult Views()
        {
            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            ProfileViewModel pvm = this.ProfileServices.GetProfileByEmployeeID(uid);
            return View(pvm);
        }

        [AuthenticationFilter]
        [EmployeeAndManagerAuthorizationFilter]
        public ActionResult Edits()
        {
            List<ProjectManagerList> ProjectManagerLists = this.ProfileServices.GetProjectManagerList();
            ViewBag.PMList = ProjectManagerLists;

            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            ProfileViewModel pvm = this.ProfileServices.GetProfileByEmployeeID(uid);
            return View(pvm);
        }

        [AuthenticationFilter]
        [EmployeeAndManagerAuthorizationFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edits(ProfileViewModel ProfileViewModels)
        {
            try
            {
                var file = Request.Files[0];
                var imagebyte = new byte[file.ContentLength - 1];
                file.InputStream.Read(imagebyte, 0, file.ContentLength - 1);
                var base64string = Convert.ToBase64String(imagebyte, 0, imagebyte.Length);
                byte[] data = Convert.FromBase64String(base64string);
                ProfileViewModels.EmployeeID = Convert.ToInt32(Session["CurrentUserID"]);
                string folderPath = Server.MapPath("~/Images/");
                folderPath = folderPath + ProfileViewModels.EmployeeID + ".jpeg";
                string imagepath = ProfileViewModels.ImageURL = "/Images/" + ProfileViewModels.EmployeeID + ".jpeg";
                System.IO.File.WriteAllBytes(folderPath, data);
                Session["CurrentUserProfilePhoto"] = ProfileViewModels.ImageURL;

            }
            catch
            {
                ProfileViewModels.EmployeeID = Convert.ToInt32(Session["CurrentUserID"]);
                ProfileViewModels.ImageURL = "/Images/" + ProfileViewModels.EmployeeID + ".jpeg";
                Session["CurrentUserProfilePhoto"] = ProfileViewModels.ImageURL;
            }


            if (ModelState.IsValid)
            {

                this.ProfileServices.UpdateEmployeeDetails(ProfileViewModels);
                return RedirectToAction("Views", "Profile");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");

                int uid = Convert.ToInt32(Session["CurrentUserID"]);
                
                return View(ProfileViewModels);
            }

        }

        [AuthenticationFilter]
        [HrAuthorizationFilter]
        public ActionResult HREmployeeView()
        {
            List<HRProfileViewModel> pvm = this.ProfileServices.GetProfile();
            return View(pvm);
        }

        [AuthenticationFilter]
        [HrAuthorizationFilter]
        [HttpPost]
        public ActionResult HREmployeeView(string role , string name)
        {
            if(name=="")
            {
                return RedirectToAction("HREmployeeView", "Profile");
            }

            List<HRProfileViewModel> pvm = this.ProfileServices.GetProfileBySearch(role,name);
            return View(pvm);
        }


        [AuthenticationFilter]
        [HrAuthorizationFilter]
        public ActionResult HREditProfile(int id)
        {
            List<ProjectManagerList> ProjectManagerLists = this.ProfileServices.GetProjectManagerList();
            ViewBag.PMList = ProjectManagerLists;

            HRProfileViewModel pvm = this.ProfileServices.HRGetProfileByEmployeeID(id);
            return View(pvm);
        }

        [AuthenticationFilter]
        [HrAuthorizationFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult HREditProfile(HRProfileViewModel HRProfileViewModels)
        {
            try
            {
                var file = Request.Files[0];
                var imagebyte = new byte[file.ContentLength - 1];
                file.InputStream.Read(imagebyte, 0, file.ContentLength - 1);
                var base64string = Convert.ToBase64String(imagebyte, 0, imagebyte.Length);
                byte[] data = Convert.FromBase64String(base64string);
                string folderPath = Server.MapPath("~/Images/");
                string imagepath = folderPath + HRProfileViewModels.EmployeeID + ".jpeg";
                HRProfileViewModels.ImageURL = "/Images/" + HRProfileViewModels.EmployeeID + ".jpeg";
                System.IO.File.WriteAllBytes(imagepath, data);
            }
            catch
            {
                HRProfileViewModels.ImageURL = "/Images/" + HRProfileViewModels.EmployeeID + ".jpeg";
            }


            if (ModelState.IsValid)
            {
                this.ProfileServices.UpdateEmployeeDetailsByHR(HRProfileViewModels);
                return RedirectToAction("HREmployeeView", "Profile");
            }
            else
            {
                List<ProjectManagerList> ProjectManagerLists = this.ProfileServices.GetProjectManagerList();
                ViewBag.PMList = ProjectManagerLists;
                ModelState.AddModelError("x", "Invalid Data");
                return View(HRProfileViewModels);
            }

        }

        [AuthenticationFilter]
        [HrAuthorizationFilter]
        public ActionResult HRDeleteProfile(int id)
        {
            this.ProfileServices.DeleteEmployee(id);

            return RedirectToAction("HREmployeeView", "Profile");
        }

        [AuthenticationFilter]
        [HrAuthorizationFilter]
        public ActionResult AddNewEmployee()
        {
            List<ProjectManagerList> ProjectManagerLists = this.ProfileServices.GetProjectManagerList();
            ViewBag.PMList = ProjectManagerLists;

            AddNewEmployeeViewModel AddNewEmployeeViewModels = new AddNewEmployeeViewModel();
            return View(AddNewEmployeeViewModels);
        }

        
        [AuthenticationFilter]
        [HrAuthorizationFilter]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewEmployee(AddNewEmployeeViewModel AddNewEmployeeViewModels)
        {
            List<ProjectManagerList> ProjectManagerLists = this.ProfileServices.GetProjectManagerList();
            ViewBag.PMList = ProjectManagerLists;

            bool valids = this.ProfileServices.CheckEmailAvailable(AddNewEmployeeViewModels.Email);

            if(valids)
            {
                if (ModelState.IsValid)
                {
                    this.ProfileServices.AddEmployee(AddNewEmployeeViewModels);
                    return RedirectToAction("HREmployeeView", "Profile");
                }
                else
                {
                    ModelState.AddModelError("x", "Invalid Data");
                }
                return View(AddNewEmployeeViewModels);
            }

            else
            {
                ModelState.AddModelError("x", "Email Already Exist");
                return View(AddNewEmployeeViewModels);
            }
           
        }

    }

}
