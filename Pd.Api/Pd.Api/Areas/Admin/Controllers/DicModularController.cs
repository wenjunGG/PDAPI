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
    public class DicModularController : Controller
    {
           private readonly IDicModularService _idicModularSerice;
            private readonly IModularService _imodularService;

            public DicModularController(IDicModularService idicModularSerice, IModularService imodularService)
            {
                _idicModularSerice = idicModularSerice;
                _imodularService = imodularService;
            }


            // GET: Admin/DicModular
            public ActionResult Index(string keyword, string ordering, int pageIndex = 1)
            {
                ViewBag.tag = "模块字典管理";

                var lisicModular = _idicModularSerice.GetAll().Select(t => new {
                    t.Modular.ModularName,
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
                var dicModular = new DicModular();
                ViewBag.tag = "模块字典新增";
                if (id.HasValue)
                {
                    dicModular = _idicModularSerice.GetById(id.Value);
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
            public ActionResult Edit(Guid? id, DicModular Collection, string ischeck, string ischeck_Impotment)
            {
                Collection.IsTure = ischeck == "on" ? true : false;
                Collection.IsImportant = ischeck_Impotment == "on" ? true : false;

                if (!ModelState.IsValid)
                {
                    Edit(id);
                    return View(Collection);
                }
                _idicModularSerice.Save(id, Collection);
                _idicModularSerice.Commit();

                return RedirectToAction("Index");
            }

        }
    }