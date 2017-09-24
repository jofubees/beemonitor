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
        public Observation GetObservations(int Id)
        {
            var observation = _context.Observations.SingleOrDefault(c => c.ObservationId == Id);

            if (observation == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return observation;
        }
        //Post  /api/observations
        [HttpPost]
        public IHttpActionResult CreateObservation(Observation observation)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            _context.Observations.Add(observation);
            _context.SaveChanges();

            // return the uri linking to the created record  i.e. "/api/obs/1"
            return Created(new Uri(Request.RequestUri + "/" + observation.ObservationId), observation);
        }


    }
}
