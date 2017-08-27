using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcGET.Models;
using MvcGET.App_Start;
using Ninject;
using OfficeOpenXml;

namespace MvcGET.Controllers
{

    public class StudentsController : Controller
    {
        public virtual ISkolaDBContext db
        {
            get; set;
        }

        [Inject()]
        public StudentsController(ISkolaDBContext SkolaDBContext)
        {
            db = SkolaDBContext;
        }

        // GET: Students
        public ActionResult Index()
        {
            return View(db.Students.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BI,Ime,Prezime,Adresa,Grad")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BI,Ime,Prezime,Adresa,Grad")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public PartialViewResult IspitDetails(int? id)
        {
            IEnumerable<Ispit> exams = db.StudentIspits
                                        .Include(i => i.Ispit)
                                        .Where(i => i.StudentId == id)
                                        .Select(i => i.Ispit);
            return PartialView("_IspitDetails", exams);
        }

        public void ExportToExcel()
        {
            Student[] students = db.Students.ToArray();
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("Students");
            workSheet.Cells[1, 1].Value = "BI";
            workSheet.Cells[1, 2].Value = "Ime";
            workSheet.Cells[1, 3].Value = "Prezime";
            workSheet.Cells[1, 4].Value = "Adresa";
            workSheet.Cells[1, 5].Value = "Grad";
            for (int i = 0; i < students.Length; i++)
            {
                var row = i + 2;
                var col = 1;
                workSheet.Cells[row, col++].Value = students[i].BI;
                workSheet.Cells[row, col++].Value = students[i].Ime;
                workSheet.Cells[row, col++].Value = students[i].Prezime;
                workSheet.Cells[row, col++].Value = students[i].Adresa;
                workSheet.Cells[row, col++].Value = students[i].Grad;
            }

            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", string.Format("attachment : filename={0}", "ExcelStudent"));
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
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
