using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amazon.IdentityManagement.Model;
using L1.Models;

namespace L1.Controllers
{
    public class HomeController : Controller
    {
    
        public ActionResult Index()
        {
           
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