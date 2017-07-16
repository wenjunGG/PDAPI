using Common.Page;
using IServices.ISysServices;
using Models.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Areas.Admin.Controllers
{
    public class PortsController : Controller
    {
        private readonly IPortsService _iportsService;
        private readonly IModularService _imodularService;

        public PortsController(IPortsService iportsService, IModularService imodularService)
        {
            _iportsService = iportsService;
            _imodularService = imodularService;
        }
        // GET: Admin/Ports
        public ActionResult Index(string keyword, string ordering, int pageIndex = 1)
        {
            ViewBag.tag = "接口管理";

            var list = _iportsService.GetAll().Select(t => new {
                t.Modular.ModularName,
                t.PortsName,
                t.PortsIp,
                t.PortsAddress,
                t.PortsType,
                t.IsPag,
                t.Remark,
                t.IsTure,
                t.Id
            });
            
            return View(list.ToPagedList(pageIndex));
        }

        public ActionResult Edit(Guid? id)
        {
            var port = new Ports();
            ViewBag.tag = "接口新增";
            if (id.HasValue)
            {
                port = _iportsService.GetById(id.Value);
                ViewBag.tag = "接口编辑";
            }

            //模块
           var ListModual=_imodularService.GetAll().Select(t => new {
               t.Id,
                t.ModularName
            }).ToList();


            ViewBag.Mo = new SelectList(ListModual, "Id", "ModularName", port.ModularID);
            
            return View(port);
        }
        [HttpPost]
        public ActionResult Edit(Guid? id, Ports Collection, string ischeck,string ischeck_page)
        {
            Collection.IsTure = ischeck == "on" ? true : false;
            Collection.IsPag = ischeck_page == "on" ? true : false;

            if (!ModelState.IsValid)
            {
                Edit(id);
                return View(Collection);
            }
            _iportsService.Save(id, Collection);
            _iportsService.Commit();

            return RedirectToAction("Index");
        }
    }
}