using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace GetShip.Models
{
    public class Wather
    {
        public int Id { get; set; }
        public int Temp { get; set; }
        public WatherStatus WatherStatus { get; set; }

        public Wather DeepClone()
        {
            Wather deepWatherClone = new Wather()
                                                {
                                                Id = this.Id,
                                                Temp = this.Temp,
                                                WatherStatus = new WatherStatus()
                                                };
            return deepWatherClone;
        }
    }


    public enum WatherStatus
    {
        Sunny , Cloudy
    }
}