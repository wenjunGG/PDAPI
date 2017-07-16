using Common.Page;
using IServices.ISysServices;
using Models.Motion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Pd.Api.Areas.Admin.Controllers
{
    public class CoefficientController : Controller
    {
        private readonly ICoefficientService _icoefficientService;
        private readonly IPortsService _iportsService;
        private readonly IModularService _imodularService;


        public CoefficientController(ICoefficientService icoefficientService, IPortsService iportsService, IModularService imodularService)
        {
            _icoefficientService = icoefficientService;
            _iportsService = iportsService;
            _imodularService = imodularService;
        }
        // GET: Admin/Coefficient
        public ActionResult Index(string keyword, string ordering, int pageIndex = 1)
        {

            ViewBag.tag = "参数管理";

            var list = _icoefficientService.GetAll().Select(t => new {
                t.Modular.ModularName,
                t.Ports.PortsName,
                t.CoeffiCode,
                t.CoffiName,
                t.Remark,
                t.IsTure,
                t.Id
            });

            return View(list.ToPagedList(pageIndex));
        }


        public ActionResult Edit(Guid? id)
        {
            var Coeffi = new Coefficient();
            ViewBag.tag = "参数新增";
            if (id.HasValue)
            {
                Coeffi = _icoefficientService.GetById(id.Value);
                ViewBag.tag = "参数编辑";
            }

            //模块
            var ListModual = _imodularService.GetAll().Select(t => new {
                t.Id,
                t.ModularName
            }).ToList();
            ViewBag.Mo = new SelectList(ListModual, "Id", "ModularName", Coeffi.ModularID);
            //接口
            Guid modualid = Guid.Empty;
            if (ListModual.Count!=0&&(Coeffi.ModularID == Guid.Empty|| Coeffi.ModularID==null))
            {
                modualid = ListModual.FirstOrDefault().Id;
            }
            var Listport = _iportsService.GetAll().Where(t=>t.ModularID== modualid).Select(t => new {
                t.Id,
                t.PortsName
            }).ToList();
            ViewBag.po = new SelectList(Listport, "Id", "PortsName", Coeffi.PortsID);




            return View(Coeffi);
        }
        [HttpPost]
        public ActionResult Edit(Guid? id, Coefficient Collection, string ischeck)
        {
            Collection.IsTure = ischeck == "on" ? true : false;

            if (!ModelState.IsValid)
            {
                Edit(id);
                return View(Collection);
            }
            _icoefficientService.Save(id, Collection);
            _icoefficientService.Commit();

            return RedirectToAction("Index");
        }



        //接口
        [HttpPost]
        public  string GetPost(string modualID)
        {
            Guid id = Guid.Parse(modualID);

            var Listport = _iportsService.GetAll().Where(t=>t.ModularID== id).Select(t => new {
                t.Id,
                t.PortsName
            }).ToList();
          return  JsonConvert.SerializeObject(Listport);
        }
    }
}