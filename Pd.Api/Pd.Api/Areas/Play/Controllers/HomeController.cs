using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Areas.Play.Controllers
{
    public class HomeController : Controller
    {
        // GET: Play/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}