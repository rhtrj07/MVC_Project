using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.ViewModels;
using MVCProject.ServiceLayer;

namespace MVCProject.Controllers
{
    public class ProfileController : Controller
    {
        IProfileService Ps;

        public ProfileController (IProfileService Ps)
        {
            this.Ps = Ps;
        }


        public ActionResult Views()
        {
            int uid = Convert.ToInt32(Session["CurrentUserID"]);
            ProfileViewModel pvm = this.Ps.GetProfileByEmployeeID(uid);
            return View(pvm);
        }
    }
}