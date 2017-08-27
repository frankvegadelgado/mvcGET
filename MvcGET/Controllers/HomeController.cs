using MvcGET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcGET.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Students");
        }

        public ActionResult Menu()
        {
            List<Meni> menus = new List<Meni>();
            menus.Add(new Meni { Name = "Students", ActionName = "Index", ControllerName = "Students" });
            menus.Add(new Meni { Name = "Ispits", ActionName = "Index", ControllerName = "Ispits" });
            menus.Add(new Meni { Name = "Students and Ispits", ActionName = "Index", ControllerName = "StudentIspits" });
            menus.Add(new Meni { Name = "Predmets", ActionName = "Index", ControllerName = "Predmets" });

            return PartialView("_Menu", menus);
        }
    }
}