using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentalClinicManagement.Models;

namespace DentalClinicManagement.Areas.WebAdmin.Controllers
{
  
    public class HomeController : Controller
    {
        graduationProjectEntities db = new graduationProjectEntities();
        // GET: WebAdmin/Home
        [User]
        public ActionResult Index()
        {
            return View();
        }
      
        public ActionResult Logout()
        {
            Session["Log"] = null;
            return RedirectToAction("Login");
        }
        public ActionResult Login()
        {
            if (Session["Log"]==null)
            {
                return View();

            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public ActionResult Login(string password,string email)
        {

            Session["log"] = db.User_Roles.Where(a => a.user_role_mail == email && a.user_role_password == password).FirstOrDefault();
            if (Session["log"]!=null)
            {
                var admin = db.User_Roles.First(d => d.user_role_mail == email && d.user_role_password == password);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
    }
}