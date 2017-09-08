using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Beemonitor.Models;
using Beemonitor.ViewModels;

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
            return View();
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

        private IEnumerable<Apiary> getApiaries()
        {
            return new List<Apiary>
            {
                new Apiary {Id = 1, Name = "garden"},
                new Apiary {Id = 2, Name = "Appletree"}
            };
        }

    }
/*    var apiary = new Apiary() { Name = "garden" };
    var beehives = new List<Beehive>
    {
    new Beehive {Name = "Flower"},
    new Beehive {Name = "Cedar"}
    };
    var viewModel
    = new ApiaryBeehivesViewModel
    {
    Apiary = apiary,
    Beehive = beehives
    };
    return View(viewModel);
*/
}