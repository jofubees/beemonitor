using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Beemonitor.Models;


namespace Beemonitor.Controllers.Api
{
    public class ApiariesController: ApiController
    {
        private ApplicationDbContext _context;

        public ApiariesController()
        {
            _context = new ApplicationDbContext();
        }

        //get  /api/observations
        public IEnumerable<Apiary> GetApiaries()
        {
            return _context.Apiaries.ToList();
        }
        //get  /api/observations/1
        public Apiary GetApiary(int id)
        {
            var apiary = _context.Apiaries.SingleOrDefault(c=> c.ApiaryId == id);

            if (apiary == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return apiary;
            
        }
        //Post  /api/apiaries
        [HttpPost]
        public Apiary CreateApiary(Apiary apiary)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Apiaries.Add(apiary);
            _context.SaveChanges();

            return apiary;
        }
       
    }
}