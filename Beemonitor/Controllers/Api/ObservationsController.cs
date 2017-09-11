using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Beemonitor.Models;

namespace Beemonitor.Controllers.Api
{
    public class ObservationsController : ApiController
    {
        private ApplicationDbContext _context;

        public ObservationsController()
        {
            _context = new ApplicationDbContext();
        }

        //get  /api/observations
        public IEnumerable<Observation> GetObservations()
        {
            return _context.Observations.ToList();
        }
        //get  /api/observations/1
        public IEnumerable<Observation> GetObservations(string HiveId)
        {
            return _context.Observations.ToList();
        }
        //Post  /api/observations
        [HttpPost]
        public Observation CreateObservation(Observation observation)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Observations.Add(observation);
            _context.SaveChanges();

            return observation;
        }


    }
}
