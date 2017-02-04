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
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ApplicationUser User { get; set; }
    }

    }
