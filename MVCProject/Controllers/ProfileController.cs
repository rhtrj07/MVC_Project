using MVCProject.Models;
using MVCProject.ServiceLayer;
using MVCProject.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;


namespace MVCProject.Controllers
{
    public class ProfileController : Controller
    {
        IProfileService ProfileServices;

        public ProfileController(IProfileService ProfileServices)
        {
            this.ProfileServices = ProfileServices;
        }

        public ActionResult Views()
        {
            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            ProfileViewModel pvm = this.ProfileServices.GetProfileByEmployeeID(uid);
            return View(pvm);
        }

        public ActionResult Edits()
        {
            List<ProjectManagerList> ProjectManagerLists = this.ProfileServices.GetProjectManagerList();
            ViewBag.PMList = ProjectManagerLists;

            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            ProfileViewModel pvm = this.ProfileServices.GetProfileByEmployeeID(uid);
            return View(pvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edits(ProfileViewModel ProfileViewModel)
        {
            try
            {
                var file = Request.Files[0];
                var imagebyte = new byte[file.ContentLength - 1];
                file.InputStream.Read(imagebyte, 0, file.ContentLength - 1);
                var base64string = Convert.ToBase64String(imagebyte, 0, imagebyte.Length);
                byte[] data = Convert.FromBase64String(base64string);
                ProfileViewModel.EmployeeID = Convert.ToInt32(Session["CurrentUserID"]);
                string folderPath = Server.MapPath("~/Images/");
                string imagepath = ProfileViewModel.ImageURL = "/Images/" + ProfileViewModel.EmployeeID + ".jpeg";
                System.IO.File.WriteAllBytes(imagepath, data);
                Session["CurrentUserEmail"] = ProfileViewModel.ImageURL;

            }
            catch
            {
                ProfileViewModel.EmployeeID = Convert.ToInt32(Session["CurrentUserID"]);
                ProfileViewModel.ImageURL =  "/Images/" + ProfileViewModel.EmployeeID + ".jpeg";
                Session["CurrentUserEmail"] = ProfileViewModel.ImageURL;
            }
           

            if (ModelState.IsValid)
            {

                this.ProfileServices.UpdateEmployeeDetails(ProfileViewModel);
                return RedirectToAction("Views", "Profile");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                
                return View(ProfileViewModel);
            }

        }

        public ActionResult HREmployeeView()
        {
            List<HRProfileViewModel> pvm = this.ProfileServices.GetProfile();
            return View(pvm);
        }

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

        public ActionResult HREditProfile(int id)
        {
            List<ProjectManagerList> ProjectManagerLists = this.ProfileServices.GetProjectManagerList();
            ViewBag.PMList = ProjectManagerLists;

            HRProfileViewModel pvm = this.ProfileServices.HRGetProfileByEmployeeID(id);
            return View(pvm);
        }

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
                HRProfileViewModels.EmployeeID = Convert.ToInt32(Session["CurrentUserID"]);
                string folderPath = Server.MapPath("~/Images/");
                string imagepath = folderPath + HRProfileViewModels.EmployeeID + ".jpeg";
                HRProfileViewModels.ImageURL = "/Images/" + HRProfileViewModels.EmployeeID + ".jpeg";
                string path = Path.Combine(Environment.CurrentDirectory, @"Data", "Images");
                System.IO.File.WriteAllBytes(imagepath, data);
            }
            catch
            {
                HRProfileViewModels.EmployeeID = Convert.ToInt32(Session["CurrentUserID"]);
                HRProfileViewModels.ImageURL = "/Images/" + HRProfileViewModels.EmployeeID + ".jpeg";
                Session["CurrentUserEmail"] = HRProfileViewModels.ImageURL;
            }


            if (ModelState.IsValid)
            {
                this.ProfileServices.UpdateEmployeeDetailsByHR(HRProfileViewModels);
                return RedirectToAction("HREmployeeView", "Profile");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View(HRProfileViewModels);
            }

        }



        public ActionResult HRDeleteProfile(int id)
        {
            this.ProfileServices.DeleteEmployee(id);

            return RedirectToAction("HREmployeeView", "Profile");
        }


        public ActionResult AddNewEmployee()
        {
            List<ProjectManagerList> ProjectManagerLists = this.ProfileServices.GetProjectManagerList();
            ViewBag.PMList = ProjectManagerLists;


            AddNewEmployeeViewModel AddNewEmployeeViewModels = new AddNewEmployeeViewModel();
            return View(AddNewEmployeeViewModels);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewEmployee(AddNewEmployeeViewModel AddNewEmployeeViewModels)
        {
            List<ProjectManagerList> ProjectManagerLists = this.ProfileServices.GetProjectManagerList();
            ViewBag.PMList = ProjectManagerLists;



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

    }

}
