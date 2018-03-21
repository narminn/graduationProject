using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DentalClinicManagement.Areas.Reception.Controllers
{
    public class HomeController : Controller
    {
        // GET: Reception/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}