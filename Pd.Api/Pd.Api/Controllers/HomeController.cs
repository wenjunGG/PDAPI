using IServices.ISysServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          
            return RedirectToAction("Index", "Home", new { area = "Play" });
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult All()
        {
            return View();
        }

        public ActionResult Gallery()
        {
            return View();
        }


    }
}