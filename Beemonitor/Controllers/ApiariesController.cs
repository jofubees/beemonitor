using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beemonitor.Models;
using Beemonitor.ViewModels;
using Microsoft.Owin.Security.Provider;

namespace Beemonitor.Controllers
{
    public class ApiariesController : Controller
    {
        // GET: Apiaries
        private ApplicationDbContext _context;

        public ApiariesController()
        {
           _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            return View("ApiaryForm");
        }

        [HttpPost]
        public ActionResult Save(Apiary apiary)
        {
            if (apiary.Id == 0)
                _context.Apiaries.Add(apiary);
            else
            {
                var apiaryInDB = _context.Apiaries.Single(c => c.Id == apiary.Id);
                apiaryInDB.Name = apiary.Name;
                apiaryInDB.Postcode = apiary.Postcode;
            }
            _context.SaveChanges();
            
            return RedirectToAction("Index", "Apiaries");
        }
        public ViewResult Index()
        {
            var apiaries = _context.Apiaries;
            return View(apiaries);
        }

        public ActionResult Details(int id)
        {
            var apiary = _context.Apiaries.SingleOrDefault(a => a.Id == id);
            if (apiary == null)
                return HttpNotFound();
            return View(apiary);
        }

        public ActionResult Edit(int id)
        {
            var apiary = _context.Apiaries.SingleOrDefault(c => c.Id == id);
            if (apiary == null) return HttpNotFound();
            // otherwise call the Apiary form view with the apiary object just found from the selected id
            return View("ApiaryForm", apiary);
        }
    }
}