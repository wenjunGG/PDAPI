using Common.Utility;
using IServices.ISysServices;
using Models.Motion;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Areas.Play.Controllers
{
    public class PPortController : Controller
    {
        private readonly IPortsService _IPortsService;
        private readonly ICoefficientService _ICoefficientService;

        private static string res = "";
        public PPortController( IPortsService IPortsService, ICoefficientService ICoefficientService)
        {
            _IPortsService = IPortsService;
            _ICoefficientService = ICoefficientService;
        }
        // GET: Play/Port
        public ActionResult Index(Guid?id)
        {
            var list = _IPortsService.GetAllEnt().Where(t => t.IsTure && t.ModularID == id.Value);
            return View(list);
        }

        public ActionResult PortDetail(Guid?id)
        {
            Ports ports = new Ports();
            var port = _IPortsService.GetAllEnt().Where(t => t.Id == id.Value).FirstOrDefault();
            if (port != null)
            {
                ports = port;
            }
            var model=_ICoefficientService.GetAllEnt().Where(t => t.IsTure && t.PortsID == id);

            ViewBag.ports = ports;
            return View(model);
        }
        [HttpPost]
        public ActionResult PortDetail(FormCollection collect,string url,string PortsType)
        {
          
            NameValueCollection nameValue = new NameValueCollection();
            NameValueCollection headList = new NameValueCollection();
            foreach (var key in collect.AllKeys)
            {
                if (key == "url" || key == "PortsType") continue;
                nameValue.Add(key, collect.GetValue(key).AttemptedValue);
            }
           

         
            WebUtility.Request(url, PortsType, new NameValueCollection(), headList);
        

            res = "out";

            return RedirectToAction("Result");
        }

        public ActionResult Result()
        {
            ViewBag.reult = res;
            return View();
        }
    }
}