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
        private readonly IHeaderService _iheaderService;

        private static string res = "";
        public PPortController( IPortsService IPortsService, ICoefficientService ICoefficientService, IHeaderService iheaderService)
        {
            _IPortsService = IPortsService;
            _ICoefficientService = ICoefficientService;
            _iheaderService = iheaderService;
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
        public ActionResult PortDetail(FormCollection collect,string url,string PortsType,Guid id)
        {
            Guid modularid = Guid.Empty;
            var Ports= _IPortsService.GetAllEnt().FirstOrDefault(t => t.Id == id);
            if (Ports != null)
            {
                modularid = Ports.ModularID;
            }
            var head_List=_iheaderService.GetAllEnt().Where(t => t.ModularID == modularid);

            NameValueCollection nameValue = new NameValueCollection();
            NameValueCollection headList = new NameValueCollection();
            foreach (var key in collect.AllKeys)
            {
                if (key == "url" || key == "PortsType"||key=="id"||key== "X-Requested-With") continue;

               var head=head_List.FirstOrDefault(t => t.HeaderCode == key);
               if (head!= null)
                {
                    headList.Add(key, collect.GetValue(key).AttemptedValue);
                    continue;
                }

                nameValue.Add(key, collect.GetValue(key).AttemptedValue);
            }
           

         
           string message=WebUtility.Request(url, PortsType, nameValue, headList);

            //操作json数据

           
        

            res = message;

            return RedirectToAction("Result");
        }

        public ActionResult Result()
        {
            ViewBag.reult = res;
            return View();
        }
    }
}