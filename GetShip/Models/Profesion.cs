using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace GetShip.Models
{
    public class Profesion
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public Profesion DeepCopy()
        {
            Profesion profesionDeepCopy;
            try
            {
                profesionDeepCopy = new Profesion()
                                                            {
                                                                Id = this.Id,
                                                                Name = this.Name,
                                                                Description = this.Description
                                                            };
            }
            catch (Exception)
            {

                profesionDeepCopy = new Profesion();
            }
           
            return profesionDeepCopy;
        }
    }

}