using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetShip.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Diagnostics;
namespace GetShip.Controllers
{
    public class UserController : Controller 
    {
        ApplicationDbContext context = new ApplicationDbContext();
        //
        // GET: /User/
        public async Task<ActionResult> Index()
        {
            var current_user = context.Users;
            return View(current_user);
        }

        public async Task<ActionResult> EmployeSelary(string id)
        {
            var user = Users.GetUser(context, id);
            EmployeSelaryView x = new EmployeSelaryView();
            List<Selary> newSel = (from selar in context.Selarys
                          where selar.Employe.Id == id
                          select selar).ToList();
            ViewBag.Id = id;
            return View(user.Employe);
        }
	}
}