using GetShip.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace GetShip.Controllers
{
    public class GaleryController : Controller
    {
        //
        // GET: /Galery/
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            var imageData = db.Galerys.Find(1).ImageData;
            return new FileStreamResult(new System.IO.MemoryStream(imageData), "image/jpeg");
        }

        public ActionResult AddImage()
        {
            return View();
        }

        public static Task<Galery> PublicAddImage(HttpPostedFileBase file , string type)
        {
            GaleryController galeryControl = new GaleryController();
            return galeryControl.AddImage(file , type);
        }

        private async Task<Galery> AddImage(HttpPostedFileBase file , string type)
        {
            Galery gal = new Galery();
            if (file != null)
            {
                byte[] fileByteArray = new byte[file.ContentLength];
                //gal.ImageData = new byte[file.ContentLength];
                file.InputStream.Read(fileByteArray, 0, file.ContentLength);
                gal.ImageData = fileByteArray;
                gal.DateUploaded = DateTime.Now;
                db.Galerys.Add(gal);
                await db.SaveChangesAsync();
            }
            // after successfully uploading redirect the user
            return gal;
        }
	}
}