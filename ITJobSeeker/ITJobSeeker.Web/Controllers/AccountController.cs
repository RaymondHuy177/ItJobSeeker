using ITJobSeeker.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITJobSeeker.Web.Controllers
{
    public class AccountController : Controller
    {
        // GET: User
        public ActionResult JobSeekerRegister()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult JobSeekerRegister(JobSeekerRegisterFormViewModel jobSeekerForm)
        {
            return Json("Hello");
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}