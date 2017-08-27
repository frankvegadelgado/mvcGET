using MvcGET.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcGET.Controllers
{
    public class DataController : Controller
    {
        private readonly IPopulate pop;

        public DataController(IPopulate populate)
        {
            pop = populate;

        }

        // GET: Data
        public async Task<ActionResult> PopulateAsync(int amount)
        {
            var success = await pop.LoadAsync(amount);
            var message = (success) ? "Loaded succesfully" : "Cannot load the data"; 
            TempData["msg"] = string.Format("<script>alert('{0}');</script>", message);
            return RedirectToAction("Index", "Students"); 
        }
    }
}