using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.ViewModels;
using MVCProject.ServiceLayer;
using System.Drawing;
using System.Drawing.Imaging;


namespace MVCProject.Controllers
{
    public class ProfileController : Controller
    {
        IProfileService Ps;

        public ProfileController(IProfileService Ps)
        {
            this.Ps = Ps;
        }


        public ActionResult Views()
        {
            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            ProfileViewModel pvm = this.Ps.GetProfileByEmployeeID(uid);
            return View(pvm);
        }

        public ActionResult Edits()
        {
            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            ProfileViewModel pvm = this.Ps.GetProfileByEmployeeID(uid);
            return View(pvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edits(ProfileViewModel pvm)
        {
            var file = Request.Files[0];
            var imagebyte = new byte[file.ContentLength - 1];
            file.InputStream.Read(imagebyte, 0, file.ContentLength - 1);
            var base64string = Convert.ToBase64String(imagebyte, 0, imagebyte.Length);
            byte[] data = Convert.FromBase64String(base64string);

            pvm.EmployeeID= Convert.ToInt32(Session["CurrentUserID"]);
            //string path = AppDomain.CurrentDomain.BaseDirectory;
            string folderPath = Server.MapPath("~/Images/");

            string imagepath = folderPath+pvm.EmployeeID+".jpeg";

            pvm.ImageURL = imagepath;

            string path = Path.Combine(Environment.CurrentDirectory, @"Data\", "Images");

            System.IO.File.WriteAllBytes(imagepath, data);

            if (ModelState.IsValid)
            {
                this.Ps.UpdateEmployeeDetails(pvm);
                return RedirectToAction("Views", "Profile");
            }
            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View(pvm);
            }


        }
    }
}
