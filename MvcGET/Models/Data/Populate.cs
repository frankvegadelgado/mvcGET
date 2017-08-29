using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MvcGET.Models.Data
{
    /// <summary>
    /// Level student,
    /// Bad(0), Good(1), Excellent(2)
    /// </summary>
    enum Level { Bad = 0, Good = 1, Excellent = 2 }

    /// <summary>
    /// Populate interface
    /// </summary>
    public interface IPopulate
    {
        /// <summary>
        /// Abstract load async method
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Task bool: True if success, false otherwise</returns>
        Task<bool> LoadAsync(int amount);
    }

    /// <summary>
    /// Populate implementation
    /// </summary>
    public class Populate: IPopulate
    {
        private readonly string[] names = new string[]
        {
            "Ivan",
            "Sandra",
            "Milan",
            "Luka",
            "Rose",
            "Nikola",
            "Vladimir",
            "Ana",
            "Béla",
            "Marko",
            "Nina",
            "Sasa",
            "Boris",
            "Elena",
            "Aleksa",
            "Filip",
            "Vera",
            "Vanja",
            "Danilo",
            "Lena",
            "Maša",
            "Dragan",
            "Mina",
            "Sava",
            "Aleksandar",
            "Marija",
            "Aleks",
            "Zoran",
            "Mira",
            "Vlada",
            "Goran",
            "Magdalena",
            "Ljuba",
            "Petar",
            "Maja",
            "Саша"
        };

        private readonly string[] surnames = new string[]
        {
            "Abadžić",
            "Abramović",
            "Aćimović",
            "Aćin",
            "Adamović",
            "Adžić",
            "Aksentijević",
            "Alečković",
            "Aleksić",
            "Alempijević",
            "Anastasijević",
            "Anđelković",
            "Anđelić",
            "Anđelović",
            "Andrejević",
            "Andrejić",
            "Andrić",
            "Andrijašević",
            "Andušić",
            "Anić",
            "Aničić",
            "Antanasijević",
            "Antelj",
            "Antić",
            "Apostolović",
            "Aračić",
            "Aralica",
            "Aranđelović",
            "Arnautović",
            "Arsenijević",
            "Arsenović"
        };

        private readonly string[] cities = new string[]
        {
            "Belgrade",
            "Čačak",
            "Jagodina",
            "Kikinda",
            "Kraljevo",
            "Kragujevac",
            "Kruševac",
            "Leskovac",
            "Loznica",
            "Novi Pazar",
            "Novi Sad",
            "Niš",
            "Pančevo",
            "Pirot",
            "Požarevac",
            "Priština",
            "Smederevo",
            "Sombor",
            "Mitrovica",
            "Subotica",
            "Šabac",
            "Užice",
            "Valjevo",
            "Vranje",
            "Vršac",
            "Zaječar",
            "Zrenjanin"
        };

        private readonly string[] mitComputerScience = new string[]
        {
            "INTRODUCTION",
            "CORE ELEMENTS",
            "RECURSION",
            "DEBUGGING",
            "EFFICIENCY AND ORDER OF GROWTH",
            "MEMORY AND SEARCH METHODS",
            "HASHING AND CLASSES",
            "DATA STRUCTURES",
            "COMPILATION",
            "OPTIMIZATION PROBLEMS AND ALGORITHMS",
            "DYNAMIC PROGRAMMING",
            "ARTIFICIAL INTELLIGENCE"
        };

        private readonly Level[] levels = new Level[] { Level.Bad, Level.Good, Level.Excellent };

        private readonly ISkolaDBContext db;

        /// <summary>
        /// Constructor by IoC
        /// </summary>
        /// <param name="SkolaDBContext"></param>
        public Populate(ISkolaDBContext SkolaDBContext)
        {
            db = SkolaDBContext;
        }

        /// <summary>
        /// Populate database
        /// </summary>
        /// <returns>Task bool: True if success, false otherwise</returns>
        public async Task<bool> LoadAsync(int amount)
        {
            try
            {
                var subjects = mitComputerScience.Select(s => new Predmet { Tema = s });
                var rand = new Random(Environment.TickCount);
                var studentsResult = from name in names
                                     from surname in surnames
                                     select new Student
                                     {
                                         Ime = name,
                                         Prezime = surname,
                                         Grad = cities[rand.Next(cities.Length)]
                                     };
                var students = studentsResult.OrderBy(a => Guid.NewGuid()).Take(amount).Select(s => new Student
                {
                    Ime = s.Ime,
                    Prezime = s.Prezime,
                    Grad = s.Grad,
                    Adresa = "Adresa od " + s.Grad
                }).ToList();
                
                db.Predmets.AddRange(subjects);
                db.Students.AddRange(students);
                
                foreach (var student in students)
                {
                    foreach (var subject in subjects)
                    {
                        var scoreLevel = levels[rand.Next(levels.Length)];
                        var grade = ((scoreLevel == Level.Bad) ? 
                                        rand.Next(5, 7) :
                                        (
                                            (scoreLevel == Level.Good) ? 
                                                rand.Next(7, 9) : rand.Next(9, 11)
                                            )
                                        );

                        var exam = new Ispit { Predmet = subject, Ocena = grade };
                        db.Ispits.Add(exam);
                        var studentIspit = new StudentIspit { Student = student, Ispit = exam };
                        db.StudentIspits.Add(studentIspit);
                    }
                }

                int returnValue = await db.SaveChangesAsync();
                
                return returnValue > 0;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}