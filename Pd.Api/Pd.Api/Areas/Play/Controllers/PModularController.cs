using IServices.ISysServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Areas.Play.Controllers
{
    public class PModularController : Controller
    {

        private readonly IModularService _IModularService;
        private readonly IPortsService _IPortsService;

        public PModularController(IModularService IModularService, IPortsService IPortsService)
        {
            _IModularService = IModularService;
            _IPortsService = IPortsService;
        }
        // GET: Play/Modular
        public ActionResult Index()
        {
            var list = _IModularService.GetAllEnt().Where(t => t.IsTure);
            return View(list);
        }

        public ActionResult ModularDetail()
        {
            return View();
        }

    }
}