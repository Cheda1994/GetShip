using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using GetShip.Models;

namespace GetShip.Controllers
{
    public class HomeController : Controller
    {
        static string CurrentUserId
        {
            get
            {
                return System.Web.HttpContext.Current.User.Identity.GetUserId();
            }
            set 
            {
                CurrentUserId = value;
            }
        }
        public ActionResult Index()
        {

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