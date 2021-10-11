using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject.ViewModels;
using MVCProject.ServiceLayer;
using MVCProject.Filter;


namespace MVCProject.Controllers
{
    public class LeaveController : Controller
    {
        IUsersService UsersServices;
        ILeaveService LeaveServices;

        public LeaveController(IUsersService UsersServices, ILeaveService LeaveServices)
        {
            this.UsersServices = UsersServices;
            this.LeaveServices = LeaveServices;
        }

        [AuthenticationFilter]
        [EmployeeAuthorizationFilter]
        public ActionResult Apply()
        {
            LeaveViewModel LeaveViewModels = new LeaveViewModel();
            return View(LeaveViewModels);
        }

        [AuthenticationFilter]
        [EmployeeAuthorizationFilter]
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Apply(LeaveViewModel LeaveViewModels)
        {
            int id = Convert.ToInt32(Session["CurrentUserID"]);
            ProfileViewModel ProfileViewModels = this.UsersServices.GetManagerID(id);
            LeaveViewModels.ProjManagerID = ProfileViewModels.ProjManagerID;
            LeaveViewModels.EmployeeID = Convert.ToInt32(Session["CurrentUserID"]);
            LeaveViewModels.LeaveStatus = "Pending";

            if(ModelState.IsValid)
            {
                this.LeaveServices.InsertLeaveRequest(LeaveViewModels);
                return RedirectToAction("ViewAll", "Leave");
            }

            else
            {
                ModelState.AddModelError("x", "Invalid Data");
                return View(LeaveViewModels);
            }
            



        }

        [AuthenticationFilter]
        [EmployeeAuthorizationFilter]
        public ActionResult ViewAll()
        {
            int id = Convert.ToInt32(Session["CurrentUserID"]);
            List<LeaveViewModel> LeaveViewModels = this.LeaveServices.GetAllRequestByID(id);
            return View(LeaveViewModels);
        }


        [AuthenticationFilter]
        [ProjectManagerAuthorizationFilter]
        public ActionResult AllRequest()
        {
            int id = Convert.ToInt32(Session["CurrentUserID"]);
            List<LeaveViewModel> LeaveViewModels = this.LeaveServices.GetAllRequestByPMID(id);
            return View(LeaveViewModels);
        }

        [AuthenticationFilter]
        [ProjectManagerAuthorizationFilter]
        public ActionResult PendingRequest()
        {
            int id = Convert.ToInt32(Session["CurrentUserID"]);
            List<LeaveViewModel> LeaveViewModels = this.LeaveServices.GetAllRequestByPMID(id);
            return View(LeaveViewModels);
        }

        [AuthenticationFilter]
        [ProjectManagerAuthorizationFilter]
        public ActionResult updatestatus(UpdateStatusViewModel UpdateStatusViewModels)
        {
            int id = UpdateStatusViewModels.LeaveRequestID;
            this.LeaveServices.UpstateStatusByLeaveID(UpdateStatusViewModels);

            return RedirectToAction("allrequest", "Leave");
        }

        [AuthenticationFilter]
        [SpecialHRAuthorizationFilter]
        public ActionResult HRUpdateStatus(UpdateStatusViewModel UpdateStatusViewModels)
        {
            int id = UpdateStatusViewModels.LeaveRequestID;
            this.LeaveServices.UpstateStatusByLeaveID(UpdateStatusViewModels);

            return RedirectToAction("HRAllRequest", "Leave");
        }

        [AuthenticationFilter]
        [SpecialHRAuthorizationFilter]
        public ActionResult HRAllRequest()
        {
            
            List<LeaveViewModel> LeaveViewModels = this.LeaveServices.GetAllRequest();
            return View(LeaveViewModels);
        }
    }
}