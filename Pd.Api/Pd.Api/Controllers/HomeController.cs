using IServices.ISysServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISysUserService _isysUserservcie;

        public HomeController(ISysUserService isysUserservcie)
        {
            _isysUserservcie = isysUserservcie;
        }

        public ActionResult Index()
        {
           var ListUser=_isysUserservcie.GetAll().ToList();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult All()
        {
            return View();
        }
    }
}