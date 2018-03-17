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
    public class Open_hoursController : Controller
    {
        private graduationProjectEntities db = new graduationProjectEntities();

        // GET: WebAdmin/Open_hours
        public ActionResult Index()
        {
            return View(db.Open_hours.ToList());
        }

        // GET: WebAdmin/Open_hours/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Open_hours open_hours = db.Open_hours.Find(id);
            if (open_hours == null)
            {
                return HttpNotFound();
            }
            return View(open_hours);
        }

        // GET: WebAdmin/Open_hours/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WebAdmin/Open_hours/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,schedule,hours")] Open_hours open_hours)
        {
            if (ModelState.IsValid)
            {
                db.Open_hours.Add(open_hours);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(open_hours);
        }

        // GET: WebAdmin/Open_hours/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Open_hours open_hours = db.Open_hours.Find(id);
            if (open_hours == null)
            {
                return HttpNotFound();
            }
            return View(open_hours);
        }

        // POST: WebAdmin/Open_hours/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,schedule,hours")] Open_hours open_hours)
        {
            if (ModelState.IsValid)
            {
                db.Entry(open_hours).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(open_hours);
        }

        // GET: WebAdmin/Open_hours/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Open_hours open_hours = db.Open_hours.Find(id);
            if (open_hours == null)
            {
                return HttpNotFound();
            }
            return View(open_hours);
        }

        // POST: WebAdmin/Open_hours/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Open_hours open_hours = db.Open_hours.Find(id);
            db.Open_hours.Remove(open_hours);
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
