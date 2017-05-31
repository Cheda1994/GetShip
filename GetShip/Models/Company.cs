using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

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
                                            Name = this.Name
                                        };
            List<Employe> employes = new List<Employe>();
            Parallel.ForEach(this.Employes, 
                            new ParallelOptions { MaxDegreeOfParallelism = 10 }, 
                            (employe) => employes.Add(employe.DeepClone()));

            deepCompany.Employes = employes;
            return deepCompany;
        }
    }

}