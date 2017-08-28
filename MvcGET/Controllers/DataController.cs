using MvcGET.Models.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MvcGET.Controllers
{
    public class DataController : Controller
    {
        private readonly IPopulate pop;
        private readonly ExportTemplate mig;

        public DataController(IPopulate populate, ExportTemplate migrate)
        {
            pop = populate;
            mig = migrate;
        }

        // GET: Data
        public async Task<ActionResult> PopulateAsync()
        {
            int amount = Convert.ToInt32(ConfigurationManager.AppSettings["PopulateAmount"] ?? "0");
            var success = await pop.LoadAsync(amount);
            return RedirectToAction("Index", "Students"); 
        }

        public void DataWarehouse()
        {
            var package = mig.Export();
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", string.Format("attachment : filename={0}", "ExportedData"));
            Response.BinaryWrite(package.GetAsByteArray());
            Response.End();
            

        }
    }
}