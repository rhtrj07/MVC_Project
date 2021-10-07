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
        HRProfileViewModel HRGetProfileByEmployeeID(int UserID);
        List<HRProfileViewModel> GetProfile();
        List<HRProfileViewModel> GetProfileBySearch(string role , string name);
        List<ProjectManagerList> GetProjectManagerList();
        void UpdateEmployeeDetails(ProfileViewModel pvm);
        void AddEmployee(AddNewEmployeeViewModel AddNewEmployeeViewModels);
        void DeleteEmployee(int id);
        void UpdateEmployeeDetailsByHR(HRProfileViewModel HRProfileViewModels);


    }
    public class ProfileService : IProfileService
    {
        IProfileRepository ProfileRepositories;

        public ProfileService()
        {
            ProfileRepositories = new ProfileRepository();
        }

        public ProfileViewModel GetProfileByEmployeeID(int UserID)
        {
            EmployeeDetails p = ProfileRepositories.GetProfileByEmployeeID(UserID).FirstOrDefault();
            ProfileViewModel pvm = null;
            if (p != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<EmployeeDetails, ProfileViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                pvm = mapper.Map<EmployeeDetails, ProfileViewModel>(p);
            }
            return pvm;
        } 
        
        public HRProfileViewModel HRGetProfileByEmployeeID(int UserID)
        {
            EmployeeDetails p = ProfileRepositories.GetProfileByEmployeeID(UserID).FirstOrDefault();
            HRProfileViewModel pvm = null;
            if (p != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<EmployeeDetails, HRProfileViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                pvm = mapper.Map<EmployeeDetails, HRProfileViewModel>(p);
            }
            return pvm;
        }

        public void UpdateEmployeeDetails(ProfileViewModel pvm )
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<ProfileViewModel, EmployeeDetails>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            EmployeeDetails u = mapper.Map<ProfileViewModel, EmployeeDetails>(pvm);
            ProfileRepositories.UpdateEmployeeDetailsFromEmployee(u);
        }

        public List<HRProfileViewModel> GetProfile()
        {
            List<EmployeeDetailsName> p = ProfileRepositories.GetProfile();
            List<HRProfileViewModel> pvm = null;
            if (p != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<EmployeeDetailsName, HRProfileViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                pvm = mapper.Map<List<EmployeeDetailsName>, List<HRProfileViewModel>>(p);
            }
            return pvm;
        }

        public List<HRProfileViewModel> GetProfileBySearch(string role, string name)
        {
            List<EmployeeDetailsName> p = ProfileRepositories.GetProfileBySearch(role,name);
            List<HRProfileViewModel> pvm = null;
            if (p != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<EmployeeDetailsName, HRProfileViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                pvm = mapper.Map<List<EmployeeDetailsName>, List<HRProfileViewModel>>(p);
            }
            return pvm;
        }

        public List<ProjectManagerList> GetProjectManagerList()
        {
            List<ProjectManagerList> ProjectManagerLists = ProfileRepositories.GetProjectManagerList();
            return ProjectManagerLists;

        }

        public void UpdateEmployeeDetailsByHR(HRProfileViewModel HRProfileViewModels)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<HRProfileViewModel, EmployeeDetails>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            EmployeeDetails u = mapper.Map<HRProfileViewModel, EmployeeDetails>(HRProfileViewModels);
            ProfileRepositories.UpdateEmployeeDetailsFromHR(u);
        }

        public void AddEmployee(AddNewEmployeeViewModel AddNewEmployeeViewModels)
        {
            AddNewEmployeeViewModels.PasswordHash = SHA256HashGenerator.GenerateHash(AddNewEmployeeViewModels.PasswordHash);

            var config = new MapperConfiguration(cfg => { cfg.CreateMap<AddNewEmployeeViewModel, EmployeeDetails>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            EmployeeDetails u = mapper.Map<AddNewEmployeeViewModel, EmployeeDetails>(AddNewEmployeeViewModels);
            ProfileRepositories.InsertIntoEmployee(u);
        }

        public void DeleteEmployee(int id)
        {
            ProfileRepositories.DeleteEmployeeByID(id);
        }

    }
}