using Common.Page;
using IServices.ISysServices;
using Models.Motion;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Areas.Admin.Controllers
{
    public class DicPortsController : Controller
    {
        private readonly IDicPortsService _idicPortsService;
        private readonly IModularService _imodularService;
        private readonly IPortsService _iportsService;

        public DicPortsController(IDicPortsService idicPortsService, IModularService imodularService, IPortsService iportsService)
        {
            _idicPortsService = idicPortsService;
            _imodularService = imodularService;
            _iportsService = iportsService;
        }
        // GET: Admin/DicModular
        public ActionResult Index(string keyword, string ordering, int pageIndex = 1)
        {
            ViewBag.tag = "接口字典管理";

            var lisicModular = _idicPortsService.GetAll().Select(t => new {
                t.Modular.ModularName,
                t.Ports.PortsName,
                t.DicName,
                t.DicValue,
                t.Remark,
                t.IsImportant,
                t.IsTure,
                t.Id
            });

            return View(lisicModular.ToPagedList(pageIndex));
        }


        public ActionResult Edit(Guid? id)
        {
            var dicModular = new DicPorts();
            ViewBag.tag = "模块字典新增";
            if (id.HasValue)
            {
                dicModular = _idicPortsService.GetById(id.Value);
                ViewBag.tag = "模块字典编辑";
            }

            //模块
            var ListModual = _imodularService.GetAll().Select(t => new {
                t.Id,
                t.ModularName
            }).ToList();


            ViewBag.Mo = new SelectList(ListModual, "Id", "ModularName", dicModular.ModularID);

            return View(dicModular);
        }
        [HttpPost]
        public ActionResult Edit(Guid? id, DicPorts Collection, string ischeck, string ischeck_Impotment)
        {
            Collection.IsTure = ischeck == "on" ? true : false;
            Collection.IsImportant = ischeck_Impotment == "on" ? true : false;

            if (!ModelState.IsValid)
            {
                Edit(id);
                return View(Collection);
            }
            _idicPortsService.Save(id, Collection);
            _idicPortsService.Commit();

            return RedirectToAction("Index");
        }


        //接口
        [HttpPost]
        public string GetPost(string modualID)
        {
            Guid id = Guid.Parse(modualID);

            var Listport = _iportsService.GetAll().Where(t => t.ModularID == id).Select(t => new {
                t.Id,
                t.PortsName
            }).ToList();
            return JsonConvert.SerializeObject(Listport);
        }

    }
}