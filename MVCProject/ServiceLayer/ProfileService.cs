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
    public interface IProfileService
    {
        ProfileViewModel GetProfileByEmployeeID(int UserID);
    }

    public class ProfileService : IProfileService
    {
        IProfileRepository pr;
        
        public ProfileService()
        {
            pr = new ProfileRepository();
        }

        public ProfileViewModel GetProfileByEmployeeID(int UserID)
        {
            EmployeeDetails p = pr.GetProfileByEmployeeID(UserID).FirstOrDefault();
            ProfileViewModel pvm = null;
            if (p != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap< EmployeeDetails,ProfileViewModel >();  cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                pvm = mapper.Map<EmployeeDetails, ProfileViewModel>(p);
            }
                return pvm;


        }
       
    }
}