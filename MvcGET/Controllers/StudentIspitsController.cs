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
    public class StudentIspitsController : Controller
    {
        private SkolaDBContext db = new SkolaDBContext();

        // GET: StudentIspits
        public ActionResult Index()
        {
            var studentIspits = db.StudentIspits.Include(s => s.Ispit).Include(s => s.Student);
            return View(studentIspits.ToList());
        }

        // GET: StudentIspits/Details/5
        public ActionResult Details(int? idStudent, int? idExam)
        {
            if (idStudent == null || idExam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentIspit studentIspit = db.StudentIspits.Find(idStudent, idExam);
            if (studentIspit == null)
            {
                return HttpNotFound();
            }
            return View(studentIspit);
        }

        // GET: StudentIspits/Create
        public ActionResult Create()
        {
            ViewBag.IspitId = new SelectList(db.Ispits, "BI", "Ime");
            ViewBag.StudentId = new SelectList(db.Students, "BI", "Ime");
            return View();
        }

        // POST: StudentIspits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,IspitId")] StudentIspit studentIspit)
        {
            if (ModelState.IsValid)
            {
                db.StudentIspits.Add(studentIspit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IspitId = new SelectList(db.Ispits, "BI", "Ime", studentIspit.IspitId);
            ViewBag.StudentId = new SelectList(db.Students, "BI", "Ime", studentIspit.StudentId);
            return View(studentIspit);
        }

        // GET: StudentIspits/Edit/5
        public ActionResult Edit(int? idStudent, int? idExam)
        {
            if (idStudent == null || idExam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentIspit studentIspit = db.StudentIspits.Find(idStudent, idExam);
            if (studentIspit == null)
            {
                return HttpNotFound();
            }
            ViewBag.IspitId = new SelectList(db.Ispits, "BI", "Ime", studentIspit.IspitId);
            ViewBag.StudentId = new SelectList(db.Students, "BI", "Ime", studentIspit.StudentId);
            return View(studentIspit);
        }

        // POST: StudentIspits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,IspitId")] StudentIspit studentIspit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(studentIspit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IspitId = new SelectList(db.Ispits, "BI", "Ime", studentIspit.IspitId);
            ViewBag.StudentId = new SelectList(db.Students, "BI", "Ime", studentIspit.StudentId);
            return View(studentIspit);
        }

        // GET: StudentIspits/Delete/5
        public ActionResult Delete(int? idStudent, int? idExam)
        {
            if (idStudent == null || idExam == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            StudentIspit studentIspit = db.StudentIspits.Find(idStudent, idExam);
            if (studentIspit == null)
            {
                return HttpNotFound();
            }
            return View(studentIspit);
        }

        // POST: StudentIspits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int idStudent, int idExam)
        {
            StudentIspit studentIspit = db.StudentIspits.Find(idStudent, idExam);
            db.StudentIspits.Remove(studentIspit);
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
