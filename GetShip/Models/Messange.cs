using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetShip.Models
{
    public class Messange
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public ApplicationUser Author { set; get; }
    }
}