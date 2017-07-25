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
    public class HeadController : Controller
    {
        private readonly IHeaderService _iheaderService;//header
        private readonly IModularService _imodularService;

        public HeadController(IHeaderService iheaderService, IModularService imodularService)
        {
            _iheaderService = iheaderService;
            _imodularService = imodularService;
        }

        // GET: Admin/Head
        public ActionResult Index(string keyword, string ordering, int pageIndex = 1)
        {
            ViewBag.tag = "Header管理";

            var list = _iheaderService.GetAll().Select(t => new {
                t.Modular.ModularName,
                t.HeaderName,
                t.HeaderCode,
                t.Remark,
                t.IsTure,
                t.Id
            });

            return View(list.ToPagedList(pageIndex));
        }


        public ActionResult Edit(Guid? id)
        {
            var head = new Header();
            ViewBag.tag = "Header新增";
            if (id.HasValue)
            {
                head = _iheaderService.GetById(id.Value);
                ViewBag.tag = "Header编辑";
            }

            //模块
            var ListModual = _imodularService.GetAll().Select(t => new {
                t.Id,
                t.ModularName
            }).ToList();
            ViewBag.Mo = new SelectList(ListModual, "Id", "ModularName", head.ModularID);

            return View(head);
        }
        [HttpPost]
        public ActionResult Edit(Guid? id, Header Collection, string ischeck)
        {
            Collection.IsTure = ischeck == "on" ? true : false;

            if (!ModelState.IsValid)
            {
                Edit(id);
                return View(Collection);
            }
            _iheaderService.Save(id, Collection);
            _iheaderService.Commit();

            return RedirectToAction("Index");
        }
    }
}