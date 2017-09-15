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
    [Authorize]
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
            var viewModel = new ApiaryFormViewModel() //creating an empty ApiaryFormViewModel
            {
                Id = 0
            };
            return View("ApiaryForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Apiary apiary)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new ApiaryFormViewModel(apiary);  //creating an apiaryformviewModel object using apiary parameter
                return View("ApiaryForm", viewModel);
            }
            if (apiary.Id == 0)
                _context.Apiaries.Add(apiary);
            else
            {
                var apiaryInDb = _context.Apiaries.Single(c => c.Id == apiary.Id); //retrieve db version of database
                apiaryInDb.Name = apiary.Name;          // and update the name
                apiaryInDb.Postcode = apiary.Postcode;  // and postcode  - nb not using tryupdatemodel as a general security risk
            }
            _context.SaveChanges();               //and save updates to database
            
            return RedirectToAction("Index", "Apiaries");   //and return to the index list of apiaries
        }
        public ViewResult Index()
        {
            var apiaries = _context.Apiaries;             // set up to retrieve all apiaries in database
            return View(apiaries);                        // and pass that list of apiaries to the view
        }

        public ActionResult Edit(int id)
        {
            var apiary = _context.Apiaries.SingleOrDefault(c => c.Id == id);  //find the apiary that matches the id parameter
            if (apiary == null) return HttpNotFound();
            // otherwise build the formview (with our current apiary) and call the Apiary form 
            var viewModel = new ApiaryFormViewModel(apiary);
            return View("ApiaryForm", viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Apiaries");   //if no parameter provided, return to index
            }
            var apiary = _context.Apiaries.SingleOrDefault(a => a.Id == id);  //get the apiary object for the parameter id
            if (apiary == null)
                return HttpNotFound();
            var viewModel = new ApiaryDetailsViewModel(apiary);    //create the viewmodel object for the found apiary object
            return View(viewModel);
        }
    }
}
