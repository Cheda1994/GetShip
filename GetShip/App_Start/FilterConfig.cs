using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace GetShip
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }


    public class ObjectsCompatibility : FilterAttribute, IActionFilter
    {

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
  
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string id = filterContext.HttpContext.Request.Url.Query.Remove(0, 4);
            if(GetShip.Models.Users.Shallow_Current_User().Company.Id != GetShip.Models.Users.GetShallowUser(new Models.ApplicationDbContext() , id).Employe.Company.Id)
            {
                filterContext.Result = new RedirectResult("/Errors/NotFound");
            }
            

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
