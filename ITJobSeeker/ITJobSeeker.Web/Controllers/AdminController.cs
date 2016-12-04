using ITJobSeeker.Model.Models;
using ITJobSeeker.Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITJobSeeker.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IJobService jobService;

        public AdminController(IJobService _jobService)
        {
            jobService = _jobService;
        }
        // GET: Admin
        public ActionResult AllJobs(int page = 1)
        {
            IEnumerable<Job> jobs = jobService.GetJobsByPage(page);
            return View(jobs);
        }
    }
}