using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L1.Models;

namespace L1.Controllers
{
    public class AccessController : Controller
    {
       
            // GET: Access
            public ActionResult Index()
            {
                return View();
            }

            public ActionResult Enter(string user, string password)
            {
                try
                {
                using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
                {
                         var lst = from d in db.curUser
                              where d.email == user && d.password == password && d.idstate == 1
                              select d;
                        if (lst.Count() > 0)
                        {
                            curUser oUser = lst.First();
                            Session["User"] = oUser;
                            return Content("1");
                        }
                        else
                        {
                            return Content("Usuario invalido :(");
                        }
                    }



                }
                catch (Exception ex)
                {
                    return Content("Ocurrio un error :( " + ex.Message);
                }

            }



        }
    }