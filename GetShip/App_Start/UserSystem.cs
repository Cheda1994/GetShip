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
        public static bool CreateCompany(RegisterViewModel model)
        {
            return (bool)us.Register(model);
            
        }

        public static bool CreateEmploye(RegisterViewModel model , Company company)
        {
            return (bool)us.Register(model);
        }


    }
}