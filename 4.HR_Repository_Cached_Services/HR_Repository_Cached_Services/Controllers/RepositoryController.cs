using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR_Repository_Cached_Services.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HR_Repository_Cached_Services.Controllers
{
    public class RepositoryController : Controller
    {
        // Key is Assumed
        string Key = "ab4c5ab4-6bfd-4e0a-b481-1ac3b2df0280";
        
        RepositoryCache ClientRequest = new RepositoryCache();

        // GET: Repository
        public ActionResult Index()
        {
            string JobData;
            var ContextVal = HttpContext.Cache[Key];
            if (ContextVal!=null)
            {
                JobData = ContextVal.ToString();// fetch Cached results
            }
            else
            {
                JobData = ClientRequest.getjobdata().Result;
                if (JobData != null) // if object na in Cache call the Repository to Insert object
                {
                    ClientRequest.Add(Key, JobData, 5);// Sliding timeout of 5 min
                 
                  
                }
                else JobData = null;
            }
            if (JobData != null)// If data is available via API or Cache return json to view
            {
                List<JobModel> jml = JsonConvert.DeserializeObject<List<JobModel>>(JobData.ToString());
                return View(jml);
            }
            else
            {
                return View("error");// show error page
            }
        }

       

        // GET: Repository/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Repository/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Repository/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Repository/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Repository/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Repository/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Repository/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
