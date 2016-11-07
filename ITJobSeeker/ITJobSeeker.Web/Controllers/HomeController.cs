using ITJobSeeker.Service.ServiceInterfaces;
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

        public ActionResult Index()
        {
            return View();
        }
        
    }
}