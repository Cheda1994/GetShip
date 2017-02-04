using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetShip.Models;
using Microsoft.AspNet.Identity;
namespace GetShip.Controllers
{
    public class UserController : Controller 
    {
        //
        // GET: /User/
        public ActionResult Index()
        {
            ApplicationDbContext user = new ApplicationDbContext();
            var current_user = user.Users;
            return View(current_user);
        }

	}
}