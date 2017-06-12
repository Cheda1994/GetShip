using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Linq;

namespace GetShip
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }


    public class EmployeAccessFilter : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var identity = (System.Security.Claims.ClaimsPrincipal)System.Threading.Thread.CurrentPrincipal;
            var name = identity.Claims;
        }
    }



    public class ObjectsCompatibility : FilterAttribute, IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
  
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.Url.Query.Length > 4)
	        {
                
                if (IsValid(filterContext))
                {
                    filterContext.Result = new RedirectResult("/Errors/NotFound");
                }
	        }
            else
            {
                filterContext.Result = new RedirectResult("/Errors/NotFound");
            }
        }

        public bool IsValid(ActionExecutingContext filterContext)
        {
            string id = filterContext.HttpContext.Request.Url.Query.Remove(0, 4);
            return (GetShip.Models.Users.Shallow_Current_User().Company.Id != GetShip.Models.Users.GetShallowUser(new Models.ApplicationDbContext(), id).Employe.Company.Id) || (id == "") || (filterContext.HttpContext.Request.Url.Query.Length < 1);
        }
    }



    public class UserFiltingSystem : FilterAttribute, IAuthorizationFilter
    {
        public string conditionRole;
        public UserFiltingSystem(string role)
        {
            conditionRole = role;
        }
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = GetShip.Models.Users.Deep_Current_User();
            try {
            if (!IsValid(user))
            {
                // Unauthorized!
                filterContext.Result = new HttpUnauthorizedResult();
            }
                 }
            catch(Exception x)
            {
                filterContext.Result = new HttpUnauthorizedResult();
            }
        }

        private bool IsValid(GetShip.Models.ApplicationUser user)
        {
            // You know what to do here => go hit your RavenDb
            // and perform the necessary checks
            return user.Role == conditionRole;
        }
    }

}
