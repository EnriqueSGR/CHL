using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using L1.Controllers;
using L1.Models;
namespace L1.Filters
{
    public class VerifySession : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var oUser = (curUser)HttpContext.Current.Session["User"];

            if (oUser == null)
            {
                if (filterContext.Controller is AccessController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Access/Index");
                }
            }
            else
            {
                if (filterContext.Controller is AccessController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}