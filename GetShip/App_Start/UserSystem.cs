using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GetShip.Models;
using GetShip.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using Vereyon.Web;

namespace GetShip.App_Start
{
    public class UserSystem  : AccountController
    {
        static UserSystem us = new UserSystem();
        public static bool CreateCompany(RegisterCompanyView model)
        {
            RegisterEmployeeView v = new RegisterEmployeeView();
            return (bool)us.Register(model);
            
        }

        public static bool CreateEmploye(RegisterEmployeeView model)
        {
            return (bool)us.Register(model);
        }



        public static void CreationgEmpSemul()
        {
            Employe emp = new Employe();
            ApplicationDbContext cdb = new ApplicationDbContext();
            var user = Users.GetUser(cdb , "13e0e9f0-2f0f-4851-9a43-8d1c9b5ceee0");
            var comp = cdb.Companies.Last();
            emp.Name = "Her";

            cdb.Employees.Add(emp);
            //comp.Employes.Add(emp);
            cdb.Entry(comp).State = EntityState.Modified;
            cdb.SaveChanges();
        }



    }
}