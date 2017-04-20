using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace GetShip.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public int Age { get; set; }
        public string Role { get; set; }
        public virtual Company Company { get; set; }
        public virtual Employe Employe { get; set; }
        public virtual Galery Galery { get; set; }

      

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

        #region TestDeepCopyWithSerialize

        //public ApplicationUser DeepClone()
        //{
        //    using (var ms = new MemoryStream())
        //    {
        //        var formatter = new BinaryFormatter();
        //        formatter.Serialize(ms, this);
        //        ms.Position = 0;

        //        return (ApplicationUser)formatter.Deserialize(ms);
        //    }
        //}
        #endregion

        #region DeepCopy
        public object DeepCopy()
        {
            ApplicationUser deepCopy = new ApplicationUser()
            {
                UserName = this.UserName,
                Age = this.Age,
                Role = this.Role,
                Galery = null
            };

            if (this.Galery != null)
            {
                deepCopy.Galery = new Galery()
                {
                    Id = this.Galery.Id,
                    ImageData = this.Galery.ImageData,
                    DateUploaded = this.Galery.DateUploaded,
                    Description = this.Galery.Description,
                    Type = this.Galery.Type
                };
            }

            if (this.Employe != null)
            {
                deepCopy.Employe = new Employe()
                {
                    Name = this.Employe.Name,
                    Selarys = this.Employe.Selarys,
                    CurrentLocation = this.Employe.CurrentLocation,
                    CurrendWather = this.Employe.CurrendWather,
                    Company = this.Employe.Company
                };
            }
            else if (this.Company != null)
            {

                deepCopy.Company = new Company()
                {
                    Id = this.Company.Id,
                    Name = this.Company.Name,
                    Employes = (from x
                               in this.Company.Employes
                                select new Employe()
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    Selarys = x.Selarys,
                                    CurrentLocation = x.CurrentLocation,
                                    CurrendWather = x.CurrendWather,
                                    Company = x.Company,
                                    ApplicationUser = new ApplicationUser()
                                                        {
                                                            UserName = x.ApplicationUser.UserName,
                                                            Age = x.ApplicationUser.Age,
                                                            Role = x.ApplicationUser.Role,
                                                            Galery = x.ApplicationUser.Galery
                                                        }
                                }).ToList()
                };
            }

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

            modelBuilder.Entity<Selary>()
                .HasRequired<Employe>(e => e.Employe)
                .WithMany(s => s.Selarys);

            modelBuilder.Entity<Company>()
                .HasMany<Employe>(e => e.Employes);

            modelBuilder.Entity<ApplicationUser>()
                .HasOptional(s => s.Galery);
        }

    }
}