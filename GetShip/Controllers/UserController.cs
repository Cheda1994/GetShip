using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetShip.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
namespace GetShip.Controllers
{
    public class UserController : Controller 
    {
        ApplicationDbContext context = new ApplicationDbContext();
        //
        // GET: /User/
        public async Task<ActionResult> Index()
        {
            ApplicationDbContext user = new ApplicationDbContext();
            var current_user = user.Users;
            return View(current_user);
        }

        public async Task<ActionResult> EmployeSelary(int id)
        {

            return View();
        }
	}
}