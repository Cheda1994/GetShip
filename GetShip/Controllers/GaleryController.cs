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


        public ActionResult AddImage()
        {
            return View();
        }

        //public static Galery PublicAddImage(HttpPostedFileBase file , string type)
        //{
        //    GaleryController galeryControl = new GaleryController();
        //    return galeryControl.AddImage(file , type , new ApplicationDbContext());
        //}

        public static Galery AddImage(HttpPostedFileBase file , string type , ApplicationDbContext db)
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
                db.SaveChanges();
            }
            // after successfully uploading redirect the user
            return gal;
        }
	}
}