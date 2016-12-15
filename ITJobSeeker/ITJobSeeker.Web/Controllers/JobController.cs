using ITJobSeeker.Model.Models;
using ITJobSeeker.Service.Common;
using ITJobSeeker.Service.ServiceInterfaces;
using ITJobSeeker.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITJobSeeker.Web.Controllers
{
    public class JobController : Controller
    {
        private readonly IJobService jobService;

        public JobController(IJobService _jobService)
        {
            jobService = _jobService;
        }
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
        public ActionResult FindJobs(string keyword, string location)
        {
            List<Job> jobs = jobService.Filter(keyword, location);
            return View(jobs);
        }
        public ActionResult Detail(string id)
        {
            Job job = jobService.GetDetailJob(new Guid(id));
            JobDetailPageViewModel data = new JobDetailPageViewModel();
            data.PrepareViewModel(job, job.Comapny);
            Account account = (Account)Session["Account"];
            if (account == null)
                account = new Account();
            data.HasLogin = account.HasLoggin;
            return View(data);
        }

    }
}