using System;
using System.Collections.Generic;
using System.Linq;
using MVCProject.Models;
using MVCProject.ViewModels;
using MVCProject.Repositories;
using AutoMapper;
using AutoMapper.Configuration;


namespace MVCProject.ServiceLayer
{
    public interface ILeaveService
    {
        void InsertLeaveRequest(LeaveViewModel lvm);
        void UpstateStatusByLeaveID(UpdateStatusViewModel usvm);
        List<LeaveViewModel> GetAllRequestByID(int id);
        List<LeaveViewModel> GetAllRequestByPMID(int id);
    }


    public class LeaveService : ILeaveService
    {
        ILeaveRepository lr;

        public LeaveService()
        {
            lr = new LeaveRepository();
        }



        public void InsertLeaveRequest(LeaveViewModel lvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<LeaveViewModel, LeaveRequest>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            LeaveRequest u = mapper.Map<LeaveViewModel, LeaveRequest>(lvm);
            lr.InsertLeaveRequest(u);
        }

        public List<LeaveViewModel> GetAllRequestByID(int id)
        {
            List<LeaveRequest> ll = lr.GetAllRequestByID(id);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<LeaveRequest,LeaveViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<LeaveViewModel> u = mapper.Map<List<LeaveRequest>, List<LeaveViewModel>>( ll );
            return u;

        }

        public List<LeaveViewModel> GetAllRequestByPMID(int id)
        {
            List<LeaveRequestName> ll = lr.GetAllRequestByPMID(id);
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<LeaveRequestName, LeaveViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<LeaveViewModel> u = mapper.Map<List<LeaveRequestName>, List<LeaveViewModel>>(ll);
            return u;

        }
        
        public void UpstateStatusByLeaveID(UpdateStatusViewModel usvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<UpdateStatusViewModel, LeaveRequest>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            LeaveRequest u = mapper.Map<UpdateStatusViewModel, LeaveRequest>(usvm);
            lr.UpstateStatusByLeaveID(u);

        }
    }
}