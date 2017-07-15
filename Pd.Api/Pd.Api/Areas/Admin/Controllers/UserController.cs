using IServices.ISysServices;
using Models.SysModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        private readonly ISysUserService _isysUserService;//用户表

        public UserController(ISysUserService isysUserService)
        {
            _isysUserService = isysUserService;
        }

        // GET: Admin/User
        public ActionResult Index()
        {
            ViewBag.tag = "用户管理";

             var list=_isysUserService.GetAll().Select(t=>new{
                  t.UserName,
                  t.Remark,
                  t.Id
              });

            
            return View(list);
        }

        public ActionResult Edit(Guid? id)
        {
            var user = new SysUser();
            ViewBag.tag = "用户新增";
            if (id.HasValue)
            {
                user = _isysUserService.GetById(id.Value);
                ViewBag.tag = "用户编辑";
            }
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(Guid? id,SysUser Collection)
        {
            if (!ModelState.IsValid)
            {
                Edit(id);
                return View(Collection);
            }
            _isysUserService.Save(id,Collection);
            _isysUserService.Commit();

            return RedirectToAction("Index");
        }

    }
}