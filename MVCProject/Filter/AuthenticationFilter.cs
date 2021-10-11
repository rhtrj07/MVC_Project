using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace MVCProject.Filter
{
    public class AuthenticationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.RequestContext.HttpContext.Session["CurrentUserID"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Account", action = "Login" }));
            }
        }

    }

    public class ProjectManagerAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            
            if (filterContext.RequestContext.HttpContext.Session["CurrentUserRole"].ToString() != "Project_Manager")
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
        }

    }

    public class HrAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.RequestContext.HttpContext.Session["CurrentUserRole"].ToString() != "HR")
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
        }

    } 
    
    public class EmployeeAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.RequestContext.HttpContext.Session["CurrentUserRole"].ToString() != "Employee")
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
        }

    }
    
    public class EmployeeAndManagerAuthorizationFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.RequestContext.HttpContext.Session["CurrentUserRole"].ToString() != "Employee" && filterContext.RequestContext.HttpContext.Session["CurrentUserRole"].ToString() != "Project_Manager")
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
        }

    }

    public class SpecialHRAuthorizationFilter : ActionFilterAttribute , IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.RequestContext.HttpContext.Session["CurrentUserRole"].ToString() != "HR" || filterContext.RequestContext.HttpContext.Session["IsSpecialPermission"] is false)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
        }

    }
}
