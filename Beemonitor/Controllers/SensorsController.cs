using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beemonitor.Migrations;
using Beemonitor.Models;
using Beemonitor.ViewModels;

namespace Beemonitor.Controllers
{
    public class SensorsController : Controller
    {
        private ApplicationDbContext _context;

        public SensorsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Sensors
        public ActionResult Index()
        {
            var sensors = _context.Sensors.ToList();             // set up to retrieve all apiaries in database
            return View(sensors);                        // and pass that list of apiaries to the view
        }
    }

}