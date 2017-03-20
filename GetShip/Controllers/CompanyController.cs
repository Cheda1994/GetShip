using System;
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
using Vereyon.Web;

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
        public ActionResult AddSelary(string id, int selaryCount)
        {
            try 
	        {
            Selary selary = new Selary();
            selary.Count = selaryCount;
            selary.Date = DateTime.Now;
            //selary.Id = ((selaryCount+11)*DateTime.Now.Ticks).ToString();
            Employe empl = db.Users.Find(id).Employe;
            selary.Employe = empl;
            empl.Selarys.Add(selary);
            //db.Entry(empl).State = EntityState.Modified;
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
            if(UserSystem.CreateEmploye(model))
            {
                FlashMessage.Confirmation("The employe " + model.UserName + " was created saccesful");
            }
            else
            {
                FlashMessage.Danger("The employe " + model.UserName + " was created saccesful");
            }
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