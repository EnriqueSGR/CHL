using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L1.Models;
using L1.Models.TableViewModels;
using L1.Models.ViewModels;

namespace L1.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            List<UserTableViewModel> lst = null;
            using (AdventureWorks2017Entities db = new AdventureWorks2017Entities())
            {
                lst = (from d in db.curUser
                       where d.idstate == 1
                       orderby d.email
                       select new UserTableViewModel
                       {
                           email = d.email,
                           id = d.ID,
                           edad = d.edad
                       }).ToList();
            }

            return View(lst);
        }


        [HttpGet]
        public ActionResult Add()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Add(UserViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new AdventureWorks2017Entities())
            {
                curUser oUser = new curUser();
                oUser.idstate = 1;
                oUser.email = model.Email;
                oUser.edad = model.Edad;
                oUser.password = model.Password;

                db.curUser.Add(oUser);

                db.SaveChanges();

            }

            return Redirect(Url.Content("~/User/"));
        }


        public ActionResult Edit(int Id)
        {
            EditUserViewModel model = new EditUserViewModel();

            using (var db = new AdventureWorks2017Entities())
            {
                var oUser = db.curUser.Find(Id);
                model.Edad = (int)oUser.edad;
                model.Email = oUser.email;
                model.Id = oUser.ID;

            }


            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new AdventureWorks2017Entities())
            {
                
                var oUser = db.curUser.Find(model.Id);
                oUser.email = model.Email;
                oUser.edad = model.Edad;

                if (model.Password != null && model.Password.Trim() != "")
                {
                    oUser.password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

            }


            return Redirect(Url.Content("~/User/"));
        }
    }
}