using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace GetShip.Models
{
    public class Company
    {
        public Company()
        {
            Employes = new List<Employe>();
        }
        [Key, ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string Name { get; set; }
        [Required]
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Employe> Employes { get; set; }

        public Company DeppClone()
        {
            Company deepCompany = new Company()
                                        {
                                            Id = this.Id,
                                            Name = this.Name,
                                            Employes = this.Employes.Select(empl => empl.DeepClone()).ToList()
                                        };
            return deepCompany;
        }
    }

}