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
    [User]
    public class Customer_quotesController : Controller
    {
        private graduationProjectEntities db = new graduationProjectEntities();

        // GET: WebAdmin/Customer_quotes
        public ActionResult Index()
        {
            return View(db.Customer_quotes.ToList());
        }

        // GET: WebAdmin/Customer_quotes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_quotes customer_quotes = db.Customer_quotes.Find(id);
            if (customer_quotes == null)
            {
                return HttpNotFound();
            }
            return View(customer_quotes);
        }

        // GET: WebAdmin/Customer_quotes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: WebAdmin/Customer_quotes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,customer_name,customer_quote_text")] Customer_quotes customer_quotes)
        {
            if (ModelState.IsValid)
            {
                db.Customer_quotes.Add(customer_quotes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer_quotes);
        }

        // GET: WebAdmin/Customer_quotes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_quotes customer_quotes = db.Customer_quotes.Find(id);
            if (customer_quotes == null)
            {
                return HttpNotFound();
            }
            return View(customer_quotes);
        }

        // POST: WebAdmin/Customer_quotes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,customer_name,customer_quote_text")] Customer_quotes customer_quotes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_quotes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer_quotes);
        }

        // GET: WebAdmin/Customer_quotes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_quotes customer_quotes = db.Customer_quotes.Find(id);
            if (customer_quotes == null)
            {
                return HttpNotFound();
            }
            return View(customer_quotes);
        }

        // POST: WebAdmin/Customer_quotes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer_quotes customer_quotes = db.Customer_quotes.Find(id);
            db.Customer_quotes.Remove(customer_quotes);
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
