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
    public class BackController : Controller
    {
        private readonly IBackService _ibackService;
        private readonly IPortsService _iportsService;
        private readonly IModularService _imodularService;
        public BackController(IBackService ibackService, IPortsService iportsService, IModularService imodularService)
        {
            _ibackService =ibackService;
            _iportsService =iportsService;
            _imodularService =imodularService;
        }


        // GET: Admin/Back
        public ActionResult Index(string keyword, string ordering, int pageIndex = 1)
        {
            ViewBag.tag = "返回值管理";

            var list=_ibackService.GetAll().Select(t =>
            new {
                t.Modular.ModularName,
                t.Ports.PortsName,
                t.BackCode,
                t.BackMess,
                t.Remark,
                t.IsTure,
                t.Id
            });
            
            return View(list.ToPagedList(pageIndex));
        }

        public ActionResult Edit(Guid? id)
        {
            var back = new Back();
            ViewBag.tag = "参数新增";
            if (id.HasValue)
            {
                back = _ibackService.GetById(id.Value);
                ViewBag.tag = "参数编辑";
            }

            //模块
            var ListModual = _imodularService.GetAll().Select(t => new {
                t.Id,
                t.ModularName
            }).ToList();
            ViewBag.Mo = new SelectList(ListModual, "Id", "ModularName", back.ModularID);
            //接口
            Guid modualid = Guid.Empty;
            if (ListModual.Count != 0 && (back.ModularID == Guid.Empty || back.ModularID == null))
            {
                modualid = ListModual.FirstOrDefault().Id;
            }
            var Listport = _iportsService.GetAll().Where(t => t.ModularID == modualid).Select(t => new {
                t.Id,
                t.PortsName
            }).ToList();
            ViewBag.po = new SelectList(Listport, "Id", "PortsName", back.PortsID);

            
            return View(back);
        }
        [HttpPost]
        public ActionResult Edit(Guid? id, Back Collection, string ischeck)
        {
            Collection.IsTure = ischeck == "on" ? true : false;

            if (!ModelState.IsValid)
            {
                Edit(id);
                return View(Collection);
            }
            _ibackService.Save(id, Collection);
            _ibackService.Commit();

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
   