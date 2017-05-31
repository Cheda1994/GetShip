using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetShip.Models;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Data.Entity;
using System.Data.Entity.Core;
namespace GetShip.Controllers
{
    public class UserController : Controller 
    {

        //
        // GET: /User/
        public ActionResult Index()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var current_user = context.Users;
                return View(current_user);
            }
        }

        public ActionResult FamalyProp()
        {
            var currentUser = Users.Shallow_Current_User().Employe.Famaly;
            ViewBag.Test = currentUser.Id;
            return View(currentUser);
        }

        [HttpPost]
        public ActionResult FamalyProp(Famaly famaly)
        {
            
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                try
                {
                    famaly = context.Famalis.Find(famaly.Id);
                    context.Entry(famaly).State = EntityState.Modified;
                    context.SaveChanges();
                    return View();
                }
                catch (InvalidOperationException e)
                {
                    return View("~/Views/Errors/NotFound.aspx");
                }
            }
        }

        public ActionResult EmployeSelary(string id)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                var user = Users.GetShallowUser(context, id);
                EmployeSelaryView x = new EmployeSelaryView();
                List<Selary> newSel = (from selar in context.Selarys
                                       where selar.Employe.Id == id
                                       select selar).ToList();
                ViewBag.Id = id;
                return View(user.Employe);
            }
        }
	}
}