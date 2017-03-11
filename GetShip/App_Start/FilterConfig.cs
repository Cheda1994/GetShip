using System;
using System.Web;
using System.Web.Mvc;

namespace GetShip
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }

    public class MyAuthorizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            var user = GetShip.Models.Users.Current_User();
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
            return user.Role =="Company";
        }
    }

}
