using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beemonitor.Models;
using Beemonitor.ViewModels;

namespace Beemonitor.Controllers
{
    public class BeehivesController : Controller
    {
        private ApplicationDbContext _context;

        public BeehivesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var viewModel = new BeehiveFormViewModel() //creating an empty ApiaryFormViewModel
            {
                Id = 0
            };
            return View("BeehiveForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Beehive beehive)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BeehiveFormViewModel(beehive);  //creating an apiaryformviewModel object using apiary parameter
                return View("BeehiveForm", viewModel);
            }
            if (beehive.Id == 0)
                _context.Beehives.Add(beehive);
            else
            {
                var beehiveInDb = _context.Beehives.Single(c => c.Id == beehive.Id); //retrieve db version of database
                beehiveInDb.Name = beehive.Name;          // and update the name
            }
            _context.SaveChanges();               //and save updates to database

            return RedirectToAction("Index", "Beehives");   //and return to the index list of apiaries
        }
        public ViewResult Index()
        {
            var beehives = _context.Beehives;             // set up to retrieve all apiaries in database
            return View(beehives);                        // and pass that list of apiaries to the view
        }

        public ActionResult Edit(int id)
        {
            var beehive = _context.Beehives.SingleOrDefault(c => c.Id == id);  //find the beehive that matches the id parameter
            if (beehive == null) return HttpNotFound();
            // otherwise build the formview (with our current beehive) and call the beehive form 
            var viewModel = new BeehiveFormViewModel(beehive);
            return View("BeehiveForm", viewModel);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Beehives");   //if no parameter provided, return to index
            }
            var beehive = _context.Beehives.SingleOrDefault(a => a.Id == id);  //get the apiary object for the parameter id
            if (beehive == null)
                return HttpNotFound();
            //            var viewModel = new BeehiveDetailsViewModel(beehive);    //create the viewmodel object for the found apiary object
            var viewModel = new ApiaryDetailsViewModel();

            return View(viewModel);
        }
    }
}
