using System.Web.Http;
using Unity;
using Unity.WebApi;
using Unity.Mvc5;
using MVCProject.ServiceLayer;
using System.Web.Mvc;



namespace MVCProject
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            
            container.RegisterType<IUsersService, UsersService>();
            container.RegisterType<IProfileService, ProfileService>();
            container.RegisterType<ILeaveService, LeaveService>();


            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}