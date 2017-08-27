using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcGET.Models;

namespace MvcGET.Controllers
{
    public class IspitsController : Controller
    {
        private SkolaDBContext db = new SkolaDBContext();

        // GET: Ispits
        public ActionResult Index()
        {
            var ispits = db.Ispits.Include(i => i.Predmet);
            return View(ispits.ToList());
        }

        // GET: Ispits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = db.Ispits.Find(id);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        // GET: Ispits/Create
        public ActionResult Create()
        {
            ViewBag.PredmetId = new SelectList(db.Predmets, "BI", "Tema");
            return View();
        }

        // POST: Ispits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BI,PredmetId,Ocena")] Ispit ispit)
        {
            if (ModelState.IsValid)
            {
                db.Ispits.Add(ispit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PredmetId = new SelectList(db.Predmets, "BI", "Tema", ispit.PredmetId);
            return View(ispit);
        }

        // GET: Ispits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = db.Ispits.Find(id);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            ViewBag.PredmetId = new SelectList(db.Predmets, "BI", "Tema", ispit.PredmetId);
            return View(ispit);
        }

        // POST: Ispits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BI,PredmetId,Ocena")] Ispit ispit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ispit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PredmetId = new SelectList(db.Predmets, "BI", "Tema", ispit.PredmetId);
            return View(ispit);
        }

        // GET: Ispits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ispit ispit = db.Ispits.Find(id);
            if (ispit == null)
            {
                return HttpNotFound();
            }
            return View(ispit);
        }

        // POST: Ispits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ispit ispit = db.Ispits.Find(id);
            db.Ispits.Remove(ispit);
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
