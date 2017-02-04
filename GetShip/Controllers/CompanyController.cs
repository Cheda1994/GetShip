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
namespace GetShip.Controllers
{
    public class CompanyController : Controller
    {
        private CompanyContext db = new CompanyContext();
        //
        // GET: /Company/
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyOffice()
        {
            Users user = new Users();
            var currentUser = user.Current_User();
            Company comp = currentUser.Company;
            return View(comp);
        }


        public ActionResult NewCompany()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewCompany(RegisterViewModel model)
        {
            Company comp = new Company();
            comp.Name = "LDTStam";
            UserSystem company = new UserSystem();
            var result = company.CreateCompany(model, comp);
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