using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Diagnostics;

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
        public virtual Profesion Profesion { get; set; }
        public virtual Wather CurrendWather { get; set; }
        public virtual Company Company { get; set; }
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }


        #region GlobalDeepClone
        public Employe DeepClone()
        {
            Employe deepCloneEmpl;
            try 
	        {	        
                deepCloneEmpl = new Employe()
                {
                    Id = this.Id,
                    Name = this.Name,
                    CurrentLocation = this.CurrentLocation,
                    CurrendWather = this.CurrendWather.DeepClone(),
                    ApplicationUser = this.ApplicationUser.BaseDeepCopy()
                };

                try
                {
                    deepCloneEmpl.CurrendWather = this.CurrendWather.DeepClone();
                }
                catch (NullReferenceException)
                {

                    deepCloneEmpl.CurrendWather = null;
                }

                try
                {
                    deepCloneEmpl.Profesion = this.Profesion.DeepCopy();
                }
                catch (NullReferenceException)
                {

                    deepCloneEmpl.Profesion = null;
                }
            }
            catch (NullReferenceException)
            {
                deepCloneEmpl = null;
            }

            return (Employe)deepCloneEmpl;
        }
        #endregion

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
