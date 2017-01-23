namespace GetShip.Migrations
{
    using GetShip.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.Owin.Security;
    using GetShip.Controllers;

    internal sealed class Configuration : DbMigrationsConfiguration<GetShip.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "GetShip.Models.ApplicationDbContext";
        }

        protected override void Seed(GetShip.Models.ApplicationDbContext context)
        {
            //if (!context.Roles.Any(r => r.Name == "Blas"))
            //{
            //    var store = new RoleStore<IdentityRole>(context);
            //    var manager = new RoleManager<IdentityRole>(store);
            //    var role = new IdentityRole { Name = "Admin" };

            //    manager.Create(role);

            //}
            
        }
    }
}
