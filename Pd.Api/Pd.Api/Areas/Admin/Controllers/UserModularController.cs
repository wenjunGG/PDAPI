using Common.Page;
using IServices.ISysServices;
using Models.SysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Areas.Admin.Controllers
{
    public class UserModularController : Controller
    {
        private readonly IUserModularService _iuserModularService;
        private readonly IModularService _imodularService;
        private readonly ISysUserService _isysUserService;

        public UserModularController(IUserModularService iuserModularService, IModularService imodularService,
            ISysUserService isysUserService)
        {
            _iuserModularService = iuserModularService;
            _imodularService = imodularService;
            _isysUserService = isysUserService;
        }

        // GET: Admin/UserModular
        public ActionResult Index(string keyword, string ordering, int pageIndex = 1)
        {
            ViewBag.tag = "用户模块管理";

            var list = _iuserModularService.GetAll().Select(t => new {
                t.SysUser.UserName,
                t.Modular.ModularName,
                t.Remark,
                t.IsTure,
                t.Id
            });

            return View(list.ToPagedList(pageIndex));
        }


        public ActionResult Edit(Guid? id)
        {
            var UserModular = new SysUserModular();
            ViewBag.tag = "用户模块新增";
            if (id.HasValue)
            {
                UserModular = _iuserModularService.GetById(id.Value);
                ViewBag.tag = "用户模块编辑";
            }

            //用户
            var ListUser = _isysUserService.GetAll().Select(t => new {
                t.Id,
                t.UserName
            }).ToList();

            ViewBag.Use = new SelectList(ListUser, "Id", "UserName", UserModular.SysUserID);


            //模块
            var ListModual = _imodularService.GetAll().Select(t => new {
                t.Id,
                t.ModularName
            }).ToList();

            ViewBag.Mo = new SelectList(ListModual, "Id", "ModularName", UserModular.ModularID);




            return View(UserModular);
        }
        [HttpPost]
        public ActionResult Edit(Guid? id, SysUserModular Collection, string ischeck)
        {
            Collection.IsTure = ischeck == "on" ? true : false;

            if (!ModelState.IsValid)
            {
                Edit(id);
                return View(Collection);
            }
            _iuserModularService.Save(id, Collection);
            _iuserModularService.Commit();

            return RedirectToAction("Index");
        }
    }
}