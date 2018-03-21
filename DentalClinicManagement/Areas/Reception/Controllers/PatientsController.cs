using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DentalClinicManagement.Models;

namespace DentalClinicManagement.Areas.Reception.Controllers
{
    public class PatientsController : Controller
    {
        private graduationProjectEntities db = new graduationProjectEntities();

        // GET: Reception/Patients
        public ActionResult Index()
        {
            var patients = db.Patients.Include(p => p.Gender).Include(p => p.MarrigeStatu);
            return View(patients.ToList());
        }

        // GET: Reception/Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Reception/Patients/Create
        public ActionResult Create()
        {
            ViewBag.patient_gender_id = new SelectList(db.Genders, "id", "gender_name");
            ViewBag.patient_marriage_status_id = new SelectList(db.MarrigeStatus, "id", "status_name");
            return View();
        }

        // POST: Reception/Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,patient_fullname,patient_gender_id,patient_marriage_status_id,patient_phone,patient_address,patient_email,patient_payment,date")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.patient_gender_id = new SelectList(db.Genders, "id", "gender_name", patient.patient_gender_id);
            ViewBag.patient_marriage_status_id = new SelectList(db.MarrigeStatus, "id", "status_name", patient.patient_marriage_status_id);
            return View(patient);
        }

        // GET: Reception/Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.patient_gender_id = new SelectList(db.Genders, "id", "gender_name", patient.patient_gender_id);
            ViewBag.patient_marriage_status_id = new SelectList(db.MarrigeStatus, "id", "status_name", patient.patient_marriage_status_id);
            return View(patient);
        }

        // POST: Reception/Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,patient_fullname,patient_gender_id,patient_marriage_status_id,patient_phone,patient_address,patient_email,patient_payment,date")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.patient_gender_id = new SelectList(db.Genders, "id", "gender_name", patient.patient_gender_id);
            ViewBag.patient_marriage_status_id = new SelectList(db.MarrigeStatus, "id", "status_name", patient.patient_marriage_status_id);
            return View(patient);
        }

        // GET: Reception/Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Reception/Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
