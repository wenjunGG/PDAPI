using IServices.ISysServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Areas.Play.Controllers
{
    public class HomeController : Controller
    {
        private readonly IModularService _IModularService;
        private readonly IPortsService _IPortsService;

        public HomeController(IModularService IModularService, IPortsService IPortsService)
        {
            _IModularService = IModularService;
            _IPortsService = IPortsService;
        }
        // GET: Play/Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Services()
        {
           return  RedirectToAction("Index","PModular","/Play/PModular");
        }

        public ActionResult Gallery()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

      
    }
}