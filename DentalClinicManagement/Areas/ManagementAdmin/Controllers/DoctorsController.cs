using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DentalClinicManagement.Models;
using System.IO;

namespace DentalClinicManagement.Areas.ManagementAdmin.Controllers
{
    public class DoctorsController : Controller
    {
        private graduationProjectEntities db = new graduationProjectEntities();

        // GET: ManagementAdmin/Doctors
        public ActionResult Index()
        {
            var doctors = db.Doctors.Include(d => d.Department).Include(d => d.Gender).Include(d => d.MarrigeStatu);
            return View(doctors.ToList());
        }

        // GET: ManagementAdmin/Doctors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // GET: ManagementAdmin/Doctors/Create
        public ActionResult Create()
        {
            ViewBag.doctor_depart_id = new SelectList(db.Departments, "id", "department_name");
            ViewBag.doctor_gender_id = new SelectList(db.Genders, "id", "gender_name");
            ViewBag.doctor_marrige_status_id = new SelectList(db.MarrigeStatus, "id", "status_name");
            return View();
        }

        // POST: ManagementAdmin/Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,doctor_fullname,doctor_about,doctor_photo,doctor_phone,doctor_address,doctor_email,doctor_depart_id,doctor_education_file,doctor_salary,doctor_marrige_status_id,doctor_begin_time,doctor_start_time,doctor_start_date,doctor_date_of_birth,doctor_gender_id")] Doctor doctor, HttpPostedFileBase doctor_photo)
        {
            if (ModelState.IsValid)
            {
                Random random = new Random();
                int randomNumber = random.Next(0, 100000);
                var date = DateTime.Now;
                var filename = Path.GetFileName(doctor_photo.FileName);
                var src = Path.Combine(Server.MapPath("~/Uploads/"), randomNumber + filename);
                doctor_photo.SaveAs(src);
                doctor.doctor_photo = "/Uploads/" + randomNumber + filename;
                db.Doctors.Add(doctor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.doctor_depart_id = new SelectList(db.Departments, "id", "department_name", doctor.doctor_depart_id);
            ViewBag.doctor_gender_id = new SelectList(db.Genders, "id", "gender_name", doctor.doctor_gender_id);
            ViewBag.doctor_marrige_status_id = new SelectList(db.MarrigeStatus, "id", "status_name", doctor.doctor_marrige_status_id);
            return View(doctor);
        }

        // GET: ManagementAdmin/Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            ViewBag.doctor_depart_id = new SelectList(db.Departments, "id", "department_name", doctor.doctor_depart_id);
            ViewBag.doctor_gender_id = new SelectList(db.Genders, "id", "gender_name", doctor.doctor_gender_id);
            ViewBag.doctor_marrige_status_id = new SelectList(db.MarrigeStatus, "id", "status_name", doctor.doctor_marrige_status_id);
            return View(doctor);
        }

        // POST: ManagementAdmin/Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,doctor_fullname,doctor_about,doctor_photo,doctor_phone,doctor_address,doctor_email,doctor_depart_id,doctor_education_file,doctor_salary,doctor_marrige_status_id,doctor_begin_time,doctor_start_time,doctor_start_date,doctor_date_of_birth,doctor_gender_id")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(doctor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.doctor_depart_id = new SelectList(db.Departments, "id", "department_name", doctor.doctor_depart_id);
            ViewBag.doctor_gender_id = new SelectList(db.Genders, "id", "gender_name", doctor.doctor_gender_id);
            ViewBag.doctor_marrige_status_id = new SelectList(db.MarrigeStatus, "id", "status_name", doctor.doctor_marrige_status_id);
            return View(doctor);
        }

        // GET: ManagementAdmin/Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Doctor doctor = db.Doctors.Find(id);
            if (doctor == null)
            {
                return HttpNotFound();
            }
            return View(doctor);
        }

        // POST: ManagementAdmin/Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Doctor doctor = db.Doctors.Find(id);
            db.Doctors.Remove(doctor);
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
