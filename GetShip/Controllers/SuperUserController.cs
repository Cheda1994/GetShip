using GetShip.App_Start;
using GetShip.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vereyon.Web;

namespace GetShip.Controllers
{
    public class SuperUserController : Controller 
    {
        //
        // GET: /SuperUser/
        ApplicationDbContext dbCompany = new ApplicationDbContext(); 

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(string id)
        {
            Company getCompany = dbCompany.Companies.Find(id);
            return View(getCompany);
        }
        [HttpGet]
        public ActionResult NewCompany()
        {
            return View();
        }

        public ActionResult AllCompanies()
        {
            DbSet<Company> allCompanies = dbCompany.Companies;
            return View(allCompanies);
        }
        [HttpPost]
        public ActionResult NewCompany(RegisterCompanyView model)
        {
            Company comp = new Company();
            if((bool)UserSystem.CreateCompany(model))
            {
                FlashMessage.Confirmation("The company " + model.UserName + " was created saccesful");
            }
            else
            {
                FlashMessage.Danger("Some think was wrong");
            }
            return View();
        }

	}
}