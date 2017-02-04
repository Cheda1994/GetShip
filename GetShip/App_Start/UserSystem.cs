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
        public void CreateCompany(RegisterViewModel model,Company company)
        {           
            var user = Register(model);
            //ApplicationDbContext appCont = new ApplicationDbContext();
            //var cur_user = appCont.Users.Find(user.Id);
            //company.Name = "NewText11";
            //cur_user.Company = company;
            //appCont.Entry(cur_user).State = EntityState.Modified;
            //appCont.SaveChanges();
        }

        public static bool CreateEmploye()
        {
            var user = new ApplicationUser();
            return false;
        }


    }
}