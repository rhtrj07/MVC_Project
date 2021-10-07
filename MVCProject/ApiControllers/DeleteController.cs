using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MVCProject.ServiceLayer;
using MVCProject.ViewModels;


namespace MVCProject.ApiControllers
{

    public class DeleteController : ApiController
    {
        IUsersService UsersServices;

        public DeleteController(IUsersService UsersServices)
        {
            this.UsersServices = UsersServices;
        }

        public bool Get(string id)
        {
            
            return (this.UsersServices.CheckIfDeleteIsAllowed(Int16.Parse(id))) ;
            
        }


    }
}