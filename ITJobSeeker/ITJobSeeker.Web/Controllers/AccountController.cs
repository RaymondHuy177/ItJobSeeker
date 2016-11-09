using AutoMapper;
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
            userService.AddJobSeeker(jobSeeker);
            try
            {
                userService.SaveJobSeeker();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
            }
            return Json("Hello");
        }

        public ActionResult Login()
        {
            return View();
        }
    }
}