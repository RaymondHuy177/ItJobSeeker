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
    public class HomeController : Controller
    {
        private readonly IJobService jobService;

        public HomeController(IJobService _jobService)
        {
            this.jobService = _jobService;
        }

        public ActionResult Index(int page = 1)
        {
            bool hasLogin = false;
            Account account = (Account)Session["Account"];
            hasLogin = account != null ? true : false;
            List<Job> jobs = jobService.GetJobsByPage(page).ToList();
            JobGridViewModel jobVM = new JobGridViewModel(jobs, hasLogin);
            return View(jobVM);
        }
        [ChildActionOnly]
        public ActionResult Menu()
        {
            Account account = (Account)Session["Account"];
            if (account == null)
                account = new Account();
            return PartialView(account);
        }
    }
}