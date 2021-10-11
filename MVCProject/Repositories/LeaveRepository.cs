using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCProject.Models;

namespace MVCProject.Repositories
{
    public interface ILeaveRepository
    {
        void InsertLeaveRequest(LeaveRequest lr);
        void UpstateStatusByLeaveID(LeaveRequest lr);
        List<LeaveRequest> GetAllRequestByID(int id);
        List<LeaveRequestName> GetAllRequestByPMID(int id);
        List<LeaveRequestName> GetAllRequest();
    }

    public class LeaveRepository : ILeaveRepository
    {
        EmployeeDBContext db;

        public LeaveRepository()
        {
            db = new EmployeeDBContext();
        }

        public void InsertLeaveRequest(LeaveRequest lr)
        {
            db.LeaveRequests.Add(lr);
            db.SaveChanges();
        }

        public List<LeaveRequest> GetAllRequestByID(int id)
        {
            List<LeaveRequest> qt = db.LeaveRequests.Where(temp => temp.EmployeeID == id ).ToList();
            return qt;
        }
        
        public List<LeaveRequestName> GetAllRequestByPMID(int id)
        {
            List<LeaveRequestName> lrn = new List<LeaveRequestName>();
 
            List<LeaveRequest> qt = db.LeaveRequests.Where(temp => temp.ProjManagerID == id ).ToList();

            foreach (var item in qt)
            {
                lrn.Add(new LeaveRequestName{
                    LeaveRequestID = item.LeaveRequestID,
                    FromDate = item.FromDate,
                    ToDate = item.ToDate,
                    Description = item.Description,
                    LeaveStatus = item.LeaveStatus,
                    LeaveType = item.LeaveType,
                    FName = db.employeeDetails.Where(temp => temp.EmployeeID == item.EmployeeID).Select(m => m.FName).ToList().FirstOrDefault(),
                    LName = db.employeeDetails.Where(temp => temp.EmployeeID == item.EmployeeID).Select(m => m.LName).ToList().FirstOrDefault()
                }) ;
               
            }
            return lrn;
        } 
        
        public List<LeaveRequestName> GetAllRequest()
        {
            List<LeaveRequestName> lrn = new List<LeaveRequestName>();
 
            List<LeaveRequest> qt = db.LeaveRequests.ToList();

            foreach (var item in qt)
            {
                lrn.Add(new LeaveRequestName{
                    LeaveRequestID = item.LeaveRequestID,
                    FromDate = item.FromDate,
                    ToDate = item.ToDate,
                    Description = item.Description,
                    LeaveStatus = item.LeaveStatus,
                    LeaveType = item.LeaveType,
                    FName = db.employeeDetails.Where(temp => temp.EmployeeID == item.EmployeeID).Select(m => m.FName).ToList().FirstOrDefault(),
                    LName = db.employeeDetails.Where(temp => temp.EmployeeID == item.EmployeeID).Select(m => m.LName).ToList().FirstOrDefault()
                }) ;
               
            }
            return lrn;
        }
        
        public void UpstateStatusByLeaveID(LeaveRequest lr)
        {
            LeaveRequest lrs = db.LeaveRequests.Where(temp => temp.LeaveRequestID == lr.LeaveRequestID).FirstOrDefault();
            if (lrs != null)
            {
                lrs.LeaveStatus = lr.LeaveStatus;
                db.SaveChanges();
            }
        }
    }
}
