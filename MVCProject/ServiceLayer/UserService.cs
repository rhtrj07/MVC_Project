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
    public interface IUsersService
    {
        
        UserViewModel GetUsersByEmailAndPassword(string Email, string Password);
        
    }

    public class UsersService : IUsersService
    {
        IUsersRepository ur;

        public UsersService()
        {
            ur = new UsersRepository();
        }

        public UserViewModel GetUsersByEmailAndPassword(string Email, string Password)
        {
            EmployeeDetails u = ur.GetUsersByEmailAndPassword(Email, SHA256HashGenerator.GenerateHash(Password)).FirstOrDefault();
            UserViewModel uvm = null;
            if (u != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<EmployeeDetails, UserViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                uvm = mapper.Map<EmployeeDetails, UserViewModel>(u);
            }
            return uvm;
        }
    }
}