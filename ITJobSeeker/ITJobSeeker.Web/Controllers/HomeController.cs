using ITJobSeeker.Model.Models;
using ITJobSeeker.Service.ServiceInterfaces;
using ITJobSeeker.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITJobSeeker.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IJobService jobService;

        public HomeController(IJobService _jobService)
        {
            this.jobService = _jobService;
        }

        public ActionResult Index(int page = 1)
        {
            List<Job> jobs = jobService.GetJobsByPage(page).ToList();
            JobGridViewModel jobVM = new JobGridViewModel(jobs);
            return View(jobVM);
        }
        [ChildActionOnly]
        public ActionResult Menu()
        {
            return PartialView();
        }
    }
}