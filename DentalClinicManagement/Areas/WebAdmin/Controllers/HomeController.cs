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
        public ActionResult Index()
        {
            return View();
        }
    }
}