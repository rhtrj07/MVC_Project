using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.ViewModels;
using MVCProject.ServiceLayer;


namespace MVCProject.Controllers
{
    public class LeaveController : Controller
    {
        IUsersService us;
        ILeaveService ls;

        public LeaveController(IUsersService us, ILeaveService ls)
        {
            this.us = us;
            this.ls = ls;
        }

        // GET: Leave
        public ActionResult Apply()
        {
            LeaveViewModel lvm = new LeaveViewModel();
            return View(lvm);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Apply(LeaveViewModel lvm)
        {
            int pmid = Convert.ToInt32(Session["CurrentUserID"]);
            ProfileViewModel pvm = this.us.GetManagerID(pmid);
            lvm.ProjManagerID = pvm.ProjManagerID;
            lvm.EmployeeID = Convert.ToInt32(Session["CurrentUserID"]);
            lvm.LeaveStatus = "Pending";

            this.ls.InsertLeaveRequest(lvm);
            return RedirectToAction("index", "Home");
        }

        public ActionResult Viewall()
        {
            int id = Convert.ToInt32(Session["CurrentUserID"]);
            List<LeaveViewModel> lvm = this.ls.GetAllRequestByID(id);
            return View(lvm);
        }

        public ActionResult allrequest()
        {
            int id = Convert.ToInt32(Session["CurrentUserID"]);
            List<LeaveViewModel> lvm = this.ls.GetAllRequestByPMID(id);
            return View(lvm);
        } 
         
        public ActionResult pendingrequest()
        {
            int id = Convert.ToInt32(Session["CurrentUserID"]);
            List<LeaveViewModel> lvm = this.ls.GetAllRequestByPMID(id);
            return View(lvm);
        } 
        
        public ActionResult updatestatus(UpdateStatusViewModel usvm )
        {
            int id = usvm.LeaveRequestID;
            this.ls.UpstateStatusByLeaveID(usvm);

            return RedirectToAction("allrequest", "Leave");
        }
    }
}