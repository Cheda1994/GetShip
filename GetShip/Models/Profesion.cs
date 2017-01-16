using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GetShip.Models
{
    public class Profesion
    {
        public int ProfesionID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ProfessionContext : DbContext
    {
        public DbSet<Profesion> Professions { get; set; }
    }
}