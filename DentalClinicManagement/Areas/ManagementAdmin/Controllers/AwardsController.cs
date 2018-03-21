using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DentalClinicManagement.Models;

namespace DentalClinicManagement.Areas.ManagementAdmin.Controllers
{
    public class AwardsController : Controller
    {
        private graduationProjectEntities db = new graduationProjectEntities();

        // GET: ManagementAdmin/Awards
        public ActionResult Index()
        {
            var awards = db.Awards.Include(a => a.Doctor);
            return View(awards.ToList());
        }

        // GET: ManagementAdmin/Awards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        // GET: ManagementAdmin/Awards/Create
        public ActionResult Create()
        {
            ViewBag.award_doctor_id = new SelectList(db.Doctors, "id", "doctor_fullname");
            return View();
        }

        // POST: ManagementAdmin/Awards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,award_name,award_price,award_date,award_doctor_id")] Award award)
        {
            if (ModelState.IsValid)
            {
                db.Awards.Add(award);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.award_doctor_id = new SelectList(db.Doctors, "id", "doctor_fullname", award.award_doctor_id);
            return View(award);
        }

        // GET: ManagementAdmin/Awards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            ViewBag.award_doctor_id = new SelectList(db.Doctors, "id", "doctor_fullname", award.award_doctor_id);
            return View(award);
        }

        // POST: ManagementAdmin/Awards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,award_name,award_price,award_date,award_doctor_id")] Award award)
        {
            if (ModelState.IsValid)
            {
                db.Entry(award).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.award_doctor_id = new SelectList(db.Doctors, "id", "doctor_fullname", award.award_doctor_id);
            return View(award);
        }

        // GET: ManagementAdmin/Awards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Award award = db.Awards.Find(id);
            if (award == null)
            {
                return HttpNotFound();
            }
            return View(award);
        }

        // POST: ManagementAdmin/Awards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Award award = db.Awards.Find(id);
            db.Awards.Remove(award);
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
