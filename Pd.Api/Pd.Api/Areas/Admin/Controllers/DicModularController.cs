using IServices.ISysServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pd.Api.Areas.Admin.Controllers
{
    public class DicModularController : Controller
    {
        private readonly IDicModularSerice _idicModularSerice;
        public DicModularController(IDicModularSerice idicModularSerice)
        {
            _idicModularSerice = idicModularSerice;
        }


        // GET: Admin/DicModular
        public ActionResult Index()
        {
            return View();
        }
    }
}