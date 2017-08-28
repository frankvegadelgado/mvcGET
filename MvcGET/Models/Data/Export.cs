using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcGET.Models.Data
{

    public abstract class ExportTemplate
    {
        public abstract void Students(ExcelPackage package);
        public abstract void Ispit(ExcelPackage package);
        public abstract void Fact(ExcelPackage package);

        public ExcelPackage Export()
        {
            ExcelPackage package = new ExcelPackage();
            Ispit(package);
            Students(package);
            Fact(package);
            package.Save();
            return package;
        }
    }


    public class ExportDimensional: ExportTemplate
    {
        private readonly ISkolaDBContext db;

        public ExportDimensional(ISkolaDBContext SkolaDBContext)
        {
            db = SkolaDBContext;
        }

        public override void Fact(ExcelPackage package)
        {
            ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("Podatak");
            workSheet.Cells[1, 1].Value = "BI";
            workSheet.Cells[1, 2].Value = "Student_BI";
            workSheet.Cells[1, 3].Value = "Ispit_BI";
            // Approved
            workSheet.Cells[1, 4].Value = "Odobreno";
            // Failed
            workSheet.Cells[1, 5].Value = "Neuspešno";
            workSheet.Cells[1, 6].Value = "Ocena";
            // Level
            workSheet.Cells[1, 7].Value = "Nivo";
            var facts = (from dim in db.StudentIspits.Include("Ispit")
                        select new
                        {
                            StudentId = dim.StudentId,
                            ExamId = dim.IspitId,
                            Approved = dim.Ispit.Ocena > 5 ? 1 : 0,
                            Failed = dim.Ispit.Ocena == 5 ? 1 : 0,
                            Grade = dim.Ispit.Ocena,
                            Level = (int)((dim.Ispit.Ocena >= 9) ?
                                        Level.Excellent :
                                        ((dim.Ispit.Ocena >= 7) ?
                                            Level.Good :
                                            Level.Bad
                                        )
                                    )
                        }).ToArray();
            for (int i = 0; i < facts.Length; i++)
            {
                var row = i + 2;
                var col = 1;
                workSheet.Cells[row, col++].Value = i + 1;
                workSheet.Cells[row, col++].Value = facts[i].StudentId;
                workSheet.Cells[row, col++].Value = facts[i].ExamId;
                workSheet.Cells[row, col++].Value = facts[i].Approved;
                workSheet.Cells[row, col++].Value = facts[i].Failed;
                workSheet.Cells[row, col++].Value = facts[i].Grade;
                workSheet.Cells[row, col++].Value = facts[i].Level;
            }
        }

        public override void Ispit(ExcelPackage package)
        {
            // Course
            ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("Ispit");
            workSheet.Cells[1, 1].Value = "BI";
            workSheet.Cells[1, 2].Value = "Tema";
            Ispit[] ispit = db.Ispits.ToArray();
            for (int i = 0; i < ispit.Length; i++)
            {
                var row = i + 2;
                var col = 1;
                workSheet.Cells[row, col++].Value = ispit[i].BI;
                workSheet.Cells[row, col++].Value = ispit[i].Predmet.Tema;
            }
        }

        public override void Students(ExcelPackage package)
        {
            ExcelWorksheet workSheet = package.Workbook.Worksheets.Add("Students");
            workSheet.Cells[1, 1].Value = "BI";
            workSheet.Cells[1, 2].Value = "Ime";
            workSheet.Cells[1, 3].Value = "Prezime";
            workSheet.Cells[1, 4].Value = "Adresa";
            workSheet.Cells[1, 5].Value = "Grad";
            Student[] students = db.Students.ToArray();
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
        }
    }
}