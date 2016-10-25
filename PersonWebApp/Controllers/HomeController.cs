using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonWebApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int? id)
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page Cheese.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}