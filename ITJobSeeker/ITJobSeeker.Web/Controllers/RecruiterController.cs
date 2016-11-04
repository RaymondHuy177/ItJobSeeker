using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITJobSeeker.Web.Controllers
{
    public class RecruiterController : Controller
    {
        // GET: Recruiter
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PostJob()
        {
            return View();
        }

        public ActionResult DeleteJob()
        {
            return View();
        }

        public ActionResult EditJob()
        {
            return View();
        }
    }
}