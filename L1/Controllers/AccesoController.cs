using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Amazon.IdentityManagement.Model;
using L1.Models;

namespace L1.Controllers
{
    public class AccesoController : Controller
    {
        public ActionResult Index(string usr, string pwd, string rme)
        {
            // Aquí cualquier uso de las variables 'usr', 'pwd' y 'rme'

            try
            {
                using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
                {
                    var lst = from d in db.curUser
                              where d.email == usr && d.password == pwd && d.idstate == 1
                              select d;
                    if (lst.Count() > 0)
                    {

                        Session["User"] = lst.First();
                        //return Content("1");
                    }
                    else
                    {
                        //return Content("0");
                    }
                }

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :( " + ex.Message);
            }

            return View("Index");
        }

        public ActionResult Enter(string usr, string pwd, string rme)
        {
            // Aquí cualquier uso de las variables 'usr', 'pwd' y 'rme'

            try
            {
                using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
                {
                    var lst = from d in db.curUser
                              where d.email == usr && d.password == pwd && d.idstate == 1
                              select d;
                    if (lst.Count() > 0)
                    {

                        Session["User"] = lst.First();
                        //return Content("1");
                    }
                    else
                    {
                        //return Content("0");
                    }
                }

            }
            catch (Exception ex)
            {
                return Content("Ocurrio un error :( " + ex.Message);
            }

            return View("Index");
        }
    }
}
