using System;
using System.Web.Mvc;

namespace Nutrition.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
