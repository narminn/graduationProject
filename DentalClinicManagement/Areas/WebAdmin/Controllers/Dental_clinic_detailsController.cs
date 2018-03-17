using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DentalClinicManagement.Models;

namespace DentalClinicManagement.Areas.WebAdmin.Controllers
{
    public class Dental_clinic_detailsController : Controller
    {
        private graduationProjectEntities db = new graduationProjectEntities();

        // GET: WebAdmin/Dental_clinic_details
        public ActionResult Index()
        {
            return View(db.Dental_clinic_details.ToList());
        }

        // GET: WebAdmin/Dental_clinic_details/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dental_clinic_details dental_clinic_details = db.Dental_clinic_details.Find(id);
            if (dental_clinic_details == null)
            {
                return HttpNotFound();
            }
            return View(dental_clinic_details);
        }

        // GET: WebAdmin/Dental_clinic_details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WebAdmin/Dental_clinic_details/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,clinic_name,clinic_about,clinic_slogan,clinic_phone,clinic_email,clinic_address,clinic_history,clinic_ceo_name,clinic_open_date")] Dental_clinic_details dental_clinic_details)
        {
            if (ModelState.IsValid)
            {
                db.Dental_clinic_details.Add(dental_clinic_details);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dental_clinic_details);
        }

        // GET: WebAdmin/Dental_clinic_details/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dental_clinic_details dental_clinic_details = db.Dental_clinic_details.Find(id);
            if (dental_clinic_details == null)
            {
                return HttpNotFound();
            }
            return View(dental_clinic_details);
        }

        // POST: WebAdmin/Dental_clinic_details/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,clinic_name,clinic_about,clinic_slogan,clinic_phone,clinic_email,clinic_address,clinic_history,clinic_ceo_name,clinic_open_date")] Dental_clinic_details dental_clinic_details)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dental_clinic_details).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dental_clinic_details);
        }

        // GET: WebAdmin/Dental_clinic_details/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dental_clinic_details dental_clinic_details = db.Dental_clinic_details.Find(id);
            if (dental_clinic_details == null)
            {
                return HttpNotFound();
            }
            return View(dental_clinic_details);
        }

        // POST: WebAdmin/Dental_clinic_details/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dental_clinic_details dental_clinic_details = db.Dental_clinic_details.Find(id);
            db.Dental_clinic_details.Remove(dental_clinic_details);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
