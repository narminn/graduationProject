using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DentalClinicManagement
{
    public class User:ActionFilterAttribute
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (HttpContext.Current.Session["Log"]==null)
            {
                filterContext.Result = new RedirectResult("~/WebAdmin/Home/Login");
            }
        }
    }
}