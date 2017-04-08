using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GetShip.Controllers
{
    public abstract partial class BaseController : Controller
    {
        //
        // GET: /Base/
        public ActionResult Index()
        {
            return View();
        }

        public GetShip.Models.ApplicationUser CurrentUSer 
        {
        get
            {
                return new Models.ApplicationUser(); 
            }
        }
	}
}