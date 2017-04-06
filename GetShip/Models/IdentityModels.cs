using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


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
    }


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