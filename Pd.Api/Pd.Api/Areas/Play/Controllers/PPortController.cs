using IServices.ISysServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Areas.Play.Controllers
{
    public class PPortController : Controller
    {
        private readonly IPortsService _IPortsService;

        public PPortController( IPortsService IPortsService)
        {
            _IPortsService = IPortsService;
        }
        // GET: Play/Port
        public ActionResult Index(Guid?id)
        {
            var list = _IPortsService.GetAllEnt().Where(t => t.IsTure && t.ModularID == id.Value);
            return View(list);
        }

        public ActionResult PortDetail()
        {
            return View();
        }
    }
}