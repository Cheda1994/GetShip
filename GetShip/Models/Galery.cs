using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using System.Text;

namespace GetShip.Models
{
    public class Galery
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public DateTime? DateUploaded { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImages { get; set; }

        public Galery DeepClone()
        {
            Galery deepGalery = new Galery()
                                    {
                                        Id = this.Id,
                                        ImageData = this.ImageData,
                                        DateUploaded = this.DateUploaded,
                                        Description = this.Description,
                                        Type = this.Type
                                    };
            return deepGalery;
        }

        public static byte[] Current_Avatar()
        {
            using(ApplicationDbContext db = new ApplicationDbContext())
	            {

                    string curentUserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
                    var avatar = db.Users.Find(curentUserId).Avatar.ImageData;
                    if(avatar == null)
                    {
                        avatar = null;
                    }
                    return avatar;
	            };       
            
        }
    }
}