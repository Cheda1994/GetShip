using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GetShip.Models;
using GetShip.Controllers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GetShip.App_Start
{
    public class UserSystem  : AccountController
    {
        public string CreateCompany(RegisterViewModel model,Company company)
        {           
            var reg = Register(model);
            
            CompanyContext context = new CompanyContext();
            Users user = new Users();
            user.GetUser(reg.Result);
            company.ApplicationUser = user.GetUser(reg.Result);
            context.Companies.Add(company);
            context.SaveChanges();
            return reg.Result;
        }

        public static bool CreateEmploye()
        {
            var user = new ApplicationUser();
            return false;
        }


    }
}