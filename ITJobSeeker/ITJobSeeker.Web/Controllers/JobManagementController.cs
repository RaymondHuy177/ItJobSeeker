using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITJobSeeker.Web.Controllers
{
    public class JobManagementController : Controller
    {
        // GET: JobManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ActiveJob(string id)
        {
            return View();
        }
        public ActionResult DeactiveJob(string id)
        {
            return View();
        }
        public ActionResult JobDetail(string id)
        {
            return View();
        }
    }
}