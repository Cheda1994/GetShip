using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GetShip.Models
{
    public class Famaly
    {
        [Key]
        public int Id { get; set; }
        public virtual Employe Employe { get; set; }
        public bool SelaryAcsess { get; set; }
        public bool WetherAcsess { get; set; }
        public bool LocationAcsess { get; set; }
        public bool GaleryAcsess { get; set; }
    }
}