namespace GetShip.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using GetShip.Models;
using System.Data.Entity.Validation;
    using System.Diagnostics;
    internal sealed class Configuration : DbMigrationsConfiguration<GetShip.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GetShip.Models.ApplicationDbContext context)
        {

            //try
            //{
            //    var comp = context.Companies.Find("cd48663c-1999-4812-8ee5-6796f81602ce");
            //    var empl = context.Employees.Find("5455a6cb-8c25-4371-a00b-4fb43d3a2170");
            //    empl.Company = comp;
            //    context.Entry(empl).State = EntityState.Modified;
            //    context.SaveChanges();
            //}
            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var valErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var valError in valErrors.ValidationErrors)
            //        {
            //            Debug.WriteLine("RABOTAET!!!!! Prop:{0} , error:{1}", valError.PropertyName, valError.ErrorMessage);
            //            Trace.TraceInformation("Prop:{0} , error:{1}", valError.PropertyName, valError.ErrorMessage);

            //        }
            //    }
            //}
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
