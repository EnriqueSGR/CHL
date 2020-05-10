using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L1.Controllers
{
    public class HomeController : Controller
    {
    
        public ActionResult Index(string usr, string pwd, string rme)
        {
            // Aquí cualquier uso de las variables 'usr', 'pwd' y 'rme'
            return View("Index");
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
    }
}