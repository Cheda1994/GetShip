using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace GetShip.Models
{
    public class Galery
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public DateTime DateUploaded { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        [NotMapped]
        public HttpPostedFileBase UploadImages { get; set; }
    }
}