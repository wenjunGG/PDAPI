using Common.Page;
using IServices.ISysServices;
using Models.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Areas.Admin.Controllers
{
    public class ModularController : Controller
    {
        private readonly IModularService _imodularService;

        public ModularController(IModularService imodularService)
        {
            _imodularService = imodularService;
        }
        // GET: Admin/Modular
        public ActionResult Index(string keyword, string ordering, int pageIndex = 1)
        {
            ViewBag.tag = "用户管理";

            var list = _imodularService.GetAll().Select(t => new {
                t.ModularName,
                t.Remark,
                t.IsTure,
                t.Id
            });


            return View(list.ToPagedList(pageIndex));
        }


        public ActionResult Edit(Guid? id)
        {
            var modular = new Modular();
            ViewBag.tag = "模块新增";
            if (id.HasValue)
            {
                modular = _imodularService.GetById(id.Value);
                ViewBag.tag = "模块编辑";
            }
            return View(modular);
        }
        [HttpPost]
        public ActionResult Edit(Guid? id, Modular Collection, string ischeck)
        {
            Collection.IsTure = ischeck == "on" ? true : false;

            if (!ModelState.IsValid)
            {
                Edit(id);
                return View(Collection);
            }
            _imodularService.Save(id, Collection);
            _imodularService.Commit();

            return RedirectToAction("Index");
        }
    }
}