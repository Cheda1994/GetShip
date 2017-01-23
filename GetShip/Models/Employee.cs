using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GetShip.Models
{
    public class Employee 
    {
        public string Id { get; set; } 
        public ICollection<double> Salary { get; set; }
        public string SecretKey { get; set; }
        public string Place { get; set; }
    }

    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employeers { get; set; }
    }
}