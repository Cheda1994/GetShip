using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GetShip.Models
{
    public class Employe
    {
        public Employe()
        {
            Selarys = new List<Selary>();
        }
        [Key, ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string Name { get; set; }
        public List<Selary> Selarys { get; set; }
        public string CurrentLocation { get; set; }
        public Wather CurrendWather { get; set; }
        public virtual Company Company { get; set; }
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }

    public class Selary
    {
        public int Id { get; set; }
        [Display(Name = "Date of pay")]
        public DateTime? Date { get; set; }
        [Display(Name = "Count")]
        public double Count { get; set; }
        [Required]
        public Employe Employe { get; set; }
    }

    public class EmployeSelaryView
    {
        public List<Selary> Selarys {get; set;}
        public Selary NewSelary { get; set;}
    }
    }
