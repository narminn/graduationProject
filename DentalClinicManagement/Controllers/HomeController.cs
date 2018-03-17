using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DentalClinicManagement.Models;

namespace DentalClinicManagement.Controllers
{
    
    public class HomeController : Controller
    {
        graduationProjectEntities db = new graduationProjectEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult About()
        {
            return View();
        }
        public ActionResult Booking()
        {
            return View();
        }
        public ActionResult Blog()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Single()
        {
            return View();
        }
        public ActionResult Doctor()
        {
            return View();
        }
        public ActionResult Service()
        {
            return View();
        }
        public ActionResult Search(string search)
        {
            IEnumerable<News> news_list = db.News.Where(n => n.news_title.Contains(search) || n.news_content.Contains(search)).ToList();
            return PartialView("PartialEmployeeSearch", news_list);
        }
    }
}