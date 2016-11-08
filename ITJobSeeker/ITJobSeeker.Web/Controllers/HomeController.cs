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
            GridJobViewModel jobVM = new GridJobViewModel(jobs);
            return View(jobVM);
        }
        
    }
}