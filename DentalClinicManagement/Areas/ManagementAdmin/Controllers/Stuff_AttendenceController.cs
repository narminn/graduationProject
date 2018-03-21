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
    public class Stuff_AttendenceController : Controller
    {
        private graduationProjectEntities db = new graduationProjectEntities();

        // GET: ManagementAdmin/Stuff_Attendence
        public ActionResult Index()
        {
            var stuff_Attendence = db.Stuff_Attendence.Include(s => s.Stuff_Attendence2);
            return View(stuff_Attendence.ToList());
        }

        // GET: ManagementAdmin/Stuff_Attendence/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stuff_Attendence stuff_Attendence = db.Stuff_Attendence.Find(id);
            if (stuff_Attendence == null)
            {
                return HttpNotFound();
            }
            return View(stuff_Attendence);
        }

        // GET: ManagementAdmin/Stuff_Attendence/Create
        public ActionResult Create()
        {
            ViewBag.stuff_id = new SelectList(db.Stuff_Attendence, "id", "id");
            return View();
        }

        // POST: ManagementAdmin/Stuff_Attendence/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,stuff_id,stuff_status")] Stuff_Attendence stuff_Attendence)
        {
            if (ModelState.IsValid)
            {
                db.Stuff_Attendence.Add(stuff_Attendence);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.stuff_id = new SelectList(db.Stuff_Attendence, "id", "id", stuff_Attendence.stuff_id);
            return View(stuff_Attendence);
        }

        // GET: ManagementAdmin/Stuff_Attendence/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stuff_Attendence stuff_Attendence = db.Stuff_Attendence.Find(id);
            if (stuff_Attendence == null)
            {
                return HttpNotFound();
            }
            ViewBag.stuff_id = new SelectList(db.Stuff_Attendence, "id", "id", stuff_Attendence.stuff_id);
            return View(stuff_Attendence);
        }

        // POST: ManagementAdmin/Stuff_Attendence/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,stuff_id,stuff_status")] Stuff_Attendence stuff_Attendence)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stuff_Attendence).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.stuff_id = new SelectList(db.Stuff_Attendence, "id", "id", stuff_Attendence.stuff_id);
            return View(stuff_Attendence);
        }

        // GET: ManagementAdmin/Stuff_Attendence/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stuff_Attendence stuff_Attendence = db.Stuff_Attendence.Find(id);
            if (stuff_Attendence == null)
            {
                return HttpNotFound();
            }
            return View(stuff_Attendence);
        }

        // POST: ManagementAdmin/Stuff_Attendence/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stuff_Attendence stuff_Attendence = db.Stuff_Attendence.Find(id);
            db.Stuff_Attendence.Remove(stuff_Attendence);
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
