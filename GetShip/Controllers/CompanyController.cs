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
        //
        // GET: /Company/
        public ActionResult Index()
        {
            return View();
        }

        [ObjectsCompatibility]
        public async Task DeleteEmploye(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var empl = await db.Employees.FindAsync(id);
                ApplicationUser user = empl.ApplicationUser;
                db.Employees.Remove(empl);
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }

        [HttpPost]
        public ActionResult AddSelary(string id, int selaryCount)
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
	        {
                
                Selary selary = new Selary();
                selary.Count = selaryCount;
                selary.Date = DateTime.Now;
                Employe empl = db.Users.Find(id).Employe;
                selary.Employe = empl;
                empl.Selarys.Add(selary);
                db.SaveChanges();
	        }
                return View("Index");
        }

        public ActionResult MyOffice()
        {
                
                var currentUser = Users.Deep_Current_User();
                Company comp = currentUser.Company;
                return View(comp);
            
            
        }
        [ObjectsCompatibility]
        public async Task<ActionResult> DetailsEmploye(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                Employe empl = await db.Employees.FindAsync(id);
                var deepCopyEmpl = empl.DeepClone();
                return View(deepCopyEmpl);
            }
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            RegisterEmployeeView model = new RegisterEmployeeView();
            model.Profesions = new SelectList(new ApplicationDbContext().Profesions, model.Profesion);
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(RegisterEmployeeView model, HttpPostedFileBase file)
        {
            model.Profesion = new Profesion() { Id = model.Profesion.Id };
            model.Role = "Employe";
            if(UserSystem.CreateEmploye(model , file))
            {
                FlashMessage.Confirmation("The employe " + model.UserName + " was created saccesful");
                return RedirectToAction("EmployList");
            }
            else
            {
                FlashMessage.Danger("The employe " + model.UserName + " was no created");
                return View();
            }
            
        }
     
        public ActionResult EmployList()
        {
                var currentCompamy = Users.Deep_Current_User().Company;
                var currentCompanyEmpl = currentCompamy;
                return View(currentCompanyEmpl.Employes); 
            
        }

        public ActionResult AddSelary(Employe empl)
        {
            return View();
        }

        [ObjectsCompatibility]
        public ActionResult Edit(string id)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                var company = db.Companies.Find(id);
                return View(company);
            }
        }

        [HttpPost]
        [ObjectsCompatibility]
        public ActionResult Edit(Company company)
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Entry(company).State = EntityState.Modified;
                db.SaveChanges();
                return View("MyOffice", company);
            }
              
        }
            
	}
}