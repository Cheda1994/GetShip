using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetShip.Models
{
    public class Wather
    {
        public int Id { get; set; }
        public int Temp { get; set; }
        public WatherStatus WatherStatus { get; set; }
    }

    public enum WatherStatus
    {
        Sunny , Cloudy
    }
}