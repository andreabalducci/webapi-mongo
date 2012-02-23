using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DreamSongs.MongoRepository;
using webapi_mongo.Models;

namespace webapi_mongo.Controllers
{
    public class WorkshopController : ApiController
    {
        static MongoRepository<Workshop>    Workshops = new MongoRepository<Workshop>();
        private static bool _checkSampleData = true;    // not thread safe.. it's a sample
        
        // GET /api/workshop
        // GET /api/workshop/?$top=1 (odata)
        // !!!!! please read http://www.mongodb.org/display/DOCS/How+to+do+Snapshotted+Queries+in+the+Mongo+Database !!!!
        public IQueryable<Workshop> Get()
        {
            CheckSampleData();
            return Workshops.All();
        }

        // GET /api/workshop/:id
        public Workshop Get(string id)
        {
            CheckSampleData();
            var w = Workshops.GetById(id);
            if(w == null)
                throw new HttpResponseException("workshop not found", HttpStatusCode.NotFound);

            return w;
        }

        // POST /api/values
        public void Post(string value)
        {
        }

        // PUT /api/values/5
        public void Put(int id, string value)
        {
        }

        // DELETE /api/values/5
        public void Delete(int id)
        {
        }

        public void CheckSampleData()
        {
            if (_checkSampleData == false)
                return;
            if (Workshops.All().Count() == 0)
            {
                Workshops.Add(new Workshop() { Location = "Castelfidardo", Title = "Mongo db in action" });
                Workshops.Add(new Workshop() { Location = "Castelfidardo", Title = "Sviluppo con jQueryMobile" });
                Workshops.Add(new Workshop() { Location = "Ancona", Title = "Asp.Net WebApi" });
            }
            
            _checkSampleData = false;
        }
    }
}