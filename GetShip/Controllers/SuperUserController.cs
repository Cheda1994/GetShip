﻿using GetShip.App_Start;
using GetShip.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using Vereyon.Web;

namespace GetShip.Controllers
{
    public class SuperUserController : Controller 
    {
        //
        // GET: /SuperUser/
        ApplicationDbContext db = new ApplicationDbContext(); 

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AllEmployee(int page)
        {
            if(page != 0)
            {
                page = 1;
            }
            var skypPoint = (-1 + page) * 5;
            var employes = (from empl
                            in db.Employees
                            select empl).ToList();
            IEnumerable<Employe> filtedEmployes = employes.Skip(skypPoint).Take(10);
            return View(filtedEmployes);
        }

        public ActionResult Details(string id)
        {
            Company getCompany = db.Companies.Find(id);
            return View(getCompany);
        }
        [HttpGet]
        public ActionResult NewCompany()
        {
            return View();
        }

        public ActionResult AllCompanies()
        {
            DbSet<Company> allCompanies = db.Companies;
            return View(allCompanies);
        }
        [HttpPost]
        public ActionResult NewCompany(RegisterCompanyView model, HttpPostedFileBase file)
        {
            Company comp = new Company();
            if((bool)UserSystem.CreateCompany(model , file))
            {
                FlashMessage.Confirmation("The company " + model.UserName + " was created saccesful");
            }
            else
            {
                FlashMessage.Danger("Some think was wrong");
            }
            return View();
        }
        
        public ActionResult ProfesionsList()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                List<Profesion> profesions = context.Profesions.ToList().Select(x => x.DeepCopy()).ToList();
                return View(profesions);    
            }
            
        }

        [HttpGet]
        public ActionResult AddProfesion()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProfesion(Profesion profesion)
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                try
                {
                    context.Profesions.Add(profesion);
                    context.SaveChanges();
                    return RedirectToAction("ProfesionsList");
                }
                catch (InvalidOperationException)
                {
                    return RedirectToAction("NotFound" , "Errors");
                }
            }
        }

        public ActionResult Selarys()
        {
            using (ApplicationDbContext context = new ApplicationDbContext())
            {
                return View(context.Selarys.ToList());    
            }
        }

	}
}