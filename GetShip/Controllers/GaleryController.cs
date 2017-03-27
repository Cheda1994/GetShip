using GetShip.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            var imageData = db.Galerys.Find(2).ImageData;
            return new FileStreamResult(new System.IO.MemoryStream(imageData), "image/jpeg");
        }

        public ActionResult AddImage()
        {
            return View();
        }

        public ActionResult Creating(HttpPostedFileBase file)
        {
            Galery gal = new Galery();
            if (file != null)
            {
                gal.ImageData = new byte[file.ContentLength];
                gal.UploadImages.InputStream.Read(gal.ImageData, 0, file.ContentLength);
                gal.DateUploaded = DateTime.Now;
                db.Galerys.Add(gal);
                db.SaveChanges();
            }
            // after successfully uploading redirect the user
            return View("Index");
        }
	}
}