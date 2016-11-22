using AutoMapper;
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
    public class AccountController : Controller
    {
        private readonly IUserService userService;

        public AccountController(IUserService _userService)
        {
            this.userService = _userService;
        }
        // GET: User
        public ActionResult JobSeekerRegister()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult JobSeekerRegister(JobSeekerRegisterFormViewModel jobSeekerForm)
        {
            var jobSeeker = Mapper.Map<JobSeekerRegisterFormViewModel, User>(jobSeekerForm);
            string message = userService.RegisterJobSeeker(jobSeeker);
            return Json(message);
        }

        public ActionResult RecruiterRegister()
        {
            return PartialView();
        }

        [HttpPost]
        public JsonResult RecruiterRegister(JobSeekerRegisterFormViewModel jobSeekerForm)
        {
            var jobSeeker = Mapper.Map<JobSeekerRegisterFormViewModel, User>(jobSeekerForm);
            string message = userService.RegisterJobSeeker(jobSeeker);
            return Json(message);
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}