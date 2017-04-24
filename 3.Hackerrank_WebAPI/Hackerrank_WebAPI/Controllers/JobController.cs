using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hackerrank_WebAPI.Models;
using Newtonsoft.Json;
using System.Web.Mvc;


namespace Hackerrank_WebAPI.Controllers
{
    
    public class JobController : ApiController
    {
        private HackerrankEntities db = new HackerrankEntities();


        // GET: api/Job/Get
        //http://localhost:xxx/api/job returns DB data for the API call in XML using the EF Datafirst model
        public List<JobModel> Get()
        {
            List<JobModel> list = db.Jobs.Select(r => new JobModel
            {
                Job_id = r.Job_id,
                CustomerName = r.CustomerName,
                Location = r.Location,
                TechniciansAssigned = r.TechniciansAssigned,
                Estimate = r.Estimate
            }).ToList();
            string s;
            // Serialize the data from Model & return
            s = JsonConvert.SerializeObject(list);
            return list;
        }

        // POST: api/Job
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Job/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Job/5
        public void Delete(int id)
        {
        }
    }
}
