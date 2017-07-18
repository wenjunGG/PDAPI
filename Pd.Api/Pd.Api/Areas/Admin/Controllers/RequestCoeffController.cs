using Common.Page;
using IServices.ISysServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Areas.Admin.Controllers
{
    public class RequestCoeffController : Controller
    {

        private readonly IModularService _imodularService;
        private readonly IPortsService _iportsService;
        private readonly IRequestCoeffService _irequestCoeffService;

        public RequestCoeffController(IModularService imodularService, IPortsService iportsService, IRequestCoeffService irequestCoeffService)
        {
            _imodularService = imodularService;
            _iportsService = iportsService;
            _irequestCoeffService = irequestCoeffService;
        }

        // GET: Admin/RequestCoeff
        public ActionResult Index(string keyword, string ordering, int pageIndex = 1)
        {
            ViewBag.tag = "请求参数管理";

            var lisicModular = _irequestCoeffService.GetAll().Select(t => new {
                t.Modular.ModularName,
                t.Ports.PortsName,
                t.CoeffCode,
                t.CoffValue,
                t.Remark,
                t.IsTure,
                t.Id
            });

            return View(lisicModular.ToPagedList(pageIndex));
        }
    }
}