using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace GetShip.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; }
        public string Role { get; set; }
        public virtual Company Company { get; set; }
        public virtual Employe Employe { get; set; }
        public virtual List<Galery> Galery { get; set; }
        public virtual Galery Avatar { get; set; }


        #region ShallowCopy
        public object ShallowCopy()
        {
            ApplicationUser shallowUser;
            if(this != null)
            {
                shallowUser = (ApplicationUser)this;
            }
            else
            {
                shallowUser = new ApplicationUser();
            }
            
            return shallowUser;
        }

       
        #endregion

        #region DeepCopy

       public ApplicationUser BaseDeepCopy()
        {
            ApplicationUser baseDeepCopy = new ApplicationUser()
            {
                Id = this.Id,
                UserName = this.UserName,
                Age = this.Age,
                Role = this.Role
            };
            baseDeepCopy.Avatar = this.Avatar.DeepClone();
            return baseDeepCopy;
        }



        public object DeepCopy()
        {
            ApplicationUser deepCopy = this.BaseDeepCopy();
            Task t1;
            Task t2;
            if (this.Avatar != null)
            {
                t1 = Task.Factory.StartNew(() => deepCopy.Avatar = this.Avatar.DeepClone());
            }

            if (this.Role == "Company")
            {
                t2 = Task.Factory.StartNew(() => deepCopy.Company = (Company)this.Company.DeppClone());
            }
            else
            {
                t2 = Task.Factory.StartNew(() => deepCopy.Employe = (Employe)this.Employe.DeepClone());
            }
            t2.Wait();
            return (ApplicationUser)deepCopy;
        }
    }
        #endregion

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Wather> Wathers { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Profesion> Profesions { get; set; }
        public DbSet<Famaly> Famalis { get; set; }
        public DbSet<Employe> Employees { get; set; }
        public DbSet<Selary> Selarys { get; set; }
        public DbSet<Galery> Galerys { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            //modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            //modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(s => s.Company);

            modelBuilder.Entity<Famaly>()
                .HasRequired(s => s.Employe);

            modelBuilder.Entity<Selary>()
                .HasRequired<Employe>(e => e.Employe)
                .WithMany(s => s.Selarys);

            modelBuilder.Entity<Company>()
                .HasMany<Employe>(e => e.Employes);

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(s => s.Avatar);
        }

    }
}