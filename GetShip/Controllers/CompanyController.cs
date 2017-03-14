﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GetShip.Models;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using GetShip.App_Start;
using System.Threading.Tasks;

namespace GetShip.Controllers
{
    [UserFiltingSystem("Company")]
    public class CompanyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        //
        // GET: /Company/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddSelary(string id)
        {
            try 
	        {	        
            ApplicationUser empl = db.Users.Find("b53e06bb-c5fb-44e9-8824-e7e85cf6174a");
            empl.Employe.Selary.Add(new Selary() {Id="as", Count = 3, Date = DateTime.Now});
            db.Entry(empl).State = EntityState.Modified;
            db.SaveChanges();
            }
             catch(DbEntityValidationException dbEx)
            {
                foreach (var valErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var valError in valErrors.ValidationErrors)
                    {
                        Debug.WriteLine("Prop:{0} , error:{1}", valError.PropertyName, valError.ErrorMessage);
                        Trace.TraceInformation("Prop:{0} , error:{1}", valError.PropertyName, valError.ErrorMessage);
                        
                    }
                }
                return View("Index");
            }
            return Index();
        }
        public ActionResult MyOffice()
        {
            var currentUser = Users.Current_User(db);
            Company comp = currentUser.Company;
            return View(comp);
        }

        public async Task<ActionResult> DetailsEmploye(string id)
        {
            Employe empl = db.Employees.Find(id);
            return View(empl);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(RegisterEmployeeView model)
        {
            model.Role = "Employe";
            UserSystem.CreateEmploye(model);
            return View();
        }
     
        public ActionResult EmployList()
        {
            var currentCompamy = Users.Current_User(db).Company;
            ICollection<Employe> currentCompanyEmpl = currentCompamy.Employes;
            return View(currentCompanyEmpl);
        }

        public ActionResult AddSelary(Employe empl)
        {
            return View();
        }
        public ActionResult Edit(string id)
        {
            var company = db.Companies.Find(id);
            return View(company);
        }

        [HttpPost]
        public ActionResult Edit(Company company)
        {
            try { 
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return View("MyOffice", company);
                }
            catch(DbEntityValidationException dbEx)
            {
                foreach (var valErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var valError in valErrors.ValidationErrors)
                    {
                        Debug.WriteLine("Prop:{0} , error:{1}", valError.PropertyName, valError.ErrorMessage);
                        Trace.TraceInformation("Prop:{0} , error:{1}", valError.PropertyName, valError.ErrorMessage);
                        
                    }
                }
                return View("Index");
            }
            

        }
	}
}