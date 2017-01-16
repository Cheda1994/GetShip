using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace GetShip.Controllers
{
    public class HomeController : Controller
    {

        public string CurrentUser
        {
            get
            {
                return User.Identity.GetUserId();
            }
        }
        
        public ActionResult Index()
        {
            ViewBag.User = CurrentUser;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}