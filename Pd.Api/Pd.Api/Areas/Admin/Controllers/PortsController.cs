using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Areas.Admin.Controllers
{
    public class PortsController : Controller
    {
        // GET: Admin/Ports
        public ActionResult Index()
        {
            return View();
        }
    }
}