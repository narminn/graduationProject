using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentalClinicManagement.Models;

namespace DentalClinicManagement.Areas.Accountant.Controllers
{
    public class SignController : Controller
    {
         
        // GET: Accountant/Sign
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Autherize(DentalClinicManagement.Models.User_Roles user_Roles)
        {
            using (graduationProjectEntities db = new graduationProjectEntities())
            {
                var userDetails = db.User_Roles.Where(x => x.user_role_name == user_Roles.user_role_name && x.user_role_password == user_Roles.user_role_password).FirstOrDefault();
                if (userDetails == null)
                {
                    user_Roles.LoginErrorMessage = "Wrong UserName or Password";
                    return View("Index", user_Roles);
                }
                else {
                    Session["userId"] = userDetails.user_role_name;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}