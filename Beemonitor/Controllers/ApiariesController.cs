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
            var viewModel = new ApiaryFormViewModel()
            {
                Id = 0
            };
            return View("ApiaryForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Apiary apiary)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ApiaryFormViewModel(apiary);
                return View("ApiaryForm", viewModel);
            }
            if (apiary.Id == 0)
                _context.Apiaries.Add(apiary);
            else
            {
                var apiaryInDB = _context.Apiaries.Single(c => c.Id == apiary.Id); //retrieve db version of database
                apiaryInDB.Name = apiary.Name;          // and update the name
                apiaryInDB.Postcode = apiary.Postcode;  // and postcode  - nb not using tryupdatemodel as a general security risk
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
            // otherwise build the formview (with our current apiary) and call the Apiary form 
            var viewModel = new ApiaryFormViewModel(apiary);
            return View("ApiaryForm", viewModel);
        }
    }
}