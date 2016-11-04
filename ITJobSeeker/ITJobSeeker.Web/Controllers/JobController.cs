using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITJobSeeker.Web.Controllers
{
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult GetAllJobs(int page = 0)
        {
            return View();
        }

        public ActionResult GetJobsByLocation(string location, int page = 0)
        {
            return View();
        }

        public ActionResult GetJobsByKeyword(string keyword, int page = 0)
        {
            return View();
        }

        public ActionResult JobDetail(string id)
        {
            return View();
        }

    }
}