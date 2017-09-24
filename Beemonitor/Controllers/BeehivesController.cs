using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
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

        public ActionResult New(int? Id)  // parameter is the owning apiary
        {
            int fred =0;

            if (Id != null)
            {
                fred = (int) Id;
            }
            if (fred ==0)
                return HttpNotFound();  // something has gone wrong if we get  here

            Apiary apiary = _context.Apiaries.Find(fred);

            var viewModel = new BeehiveFormViewModel() //creating an fresh BeehiveFormViewModel
            {
                Id = 0,
                Name = " ",
                ApiaryId = apiary.ApiaryId
            };

            return View("BeehiveForm", viewModel);
        }

        public ActionResult Edit(int id)    //parameter is the existing beehive.
        {
            var beehive = _context.Beehives.SingleOrDefault(c => c.BeehiveId == id);  //find the beehive that matches the id parameter
            if (beehive == null) return HttpNotFound();
            // otherwise build the formview (with our current beehive) and call the beehive form 
            var viewModel = new BeehiveFormViewModel(beehive);
            return View("BeehiveForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Beehive beehive)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BeehiveFormViewModel(beehive);  //creating an BeehiveformviewModel object using beehive parameter
                return View("BeehiveForm", viewModel);
            }

            if (beehive.BeehiveId == 0)
                _context.Beehives.Add(beehive);
            else
            {
                var beehiveInDb = _context.Beehives.Single(c => c.BeehiveId == beehive.BeehiveId); //retrieve db version of database
                beehiveInDb.BeehiveName = beehive.BeehiveName;          // and update the name
            }
            _context.SaveChanges();               //and save updates to database

            return RedirectToAction("Index", "Beehives");   //and return to the index list of apiaries
        }
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Apiaries") ;   //if no parameter provided, return to index
            }
            var apiary = _context.Apiaries.SingleOrDefault(a => a.ApiaryId == id);  //get the apiary object for the parameter id
            if (apiary == null)
                return HttpNotFound();
            var viewModel = new ApiaryDetailsViewModel(apiary);    //create the viewmodel object for the found apiary object
            return View(viewModel);
        }


        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Beehives");   //if no parameter provided, return to index
            }
//            var beehive = _context.Beehives.SingleOrDefault(a => a.Id == id);  //get the apiary object for the parameter id
//            if (beehive == null)
//                return HttpNotFound();

            //var viewModel = new BeehiveDetailsViewModel(beehive);    //create the viewmodel object for the found apiary object
            //var viewModel = _context.Beehives;
 
 //           var viewModel = new BeehiveDataViewModel();
            var Beehive = _context.Beehives.Include("Sensors").ToList().FirstOrDefault(p => p.BeehiveId == id);

            // viewModel.Beehive = _context.Beehives.Include(Sensors).ToList();


            // viewModel.Sensors = beehive.Sensors;

 //           viewModel.Beehive = _context.Beehives.Include(s => s.Sensors.Observations).ToList();

            /*   the contuso way of doing things - error is converting dbcontext.beehive to beehive
            viewModel.Beehive = _context.Beehives
                .Include(i => i.Sensors.Select(c => c.Observations));
            */

            return View(Beehive);
        }
    }
}
