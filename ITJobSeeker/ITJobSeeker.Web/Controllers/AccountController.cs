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
        private readonly IAuthenticateService authenticateService;

        public AccountController(IUserService _userService, IAuthenticateService _authenticateService)
        {
            userService = _userService;
            authenticateService = _authenticateService;
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
        public JsonResult RecruiterRegister(RecruiterRegisterFormViewModel recruiterForm)
        {
            StandardResponse response = new StandardResponse();
            try
            {
                var user = Mapper.Map<RecruiterRegisterFormViewModel, User>(recruiterForm);
                var company = Mapper.Map<RecruiterRegisterFormViewModel, Company>(recruiterForm);
                userService.RegisterRecruiter(user, company);
            }
            catch (Exception ex)
            {
                response.Status = 1;
                response.Message = ex.Message;
            }
            
            return Json(response);
        }

        public ActionResult Login()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Login(LoginFormViewModel loginForm)
        {
            StandardResponse response = new StandardResponse();
            try
            {
                User user = authenticateService.Login(loginForm.UserName, loginForm.Password);
                if (user != null)
                {
                    Session["User"] = user;
                }
                else
                {
                    response.Status = 1;
                    response.Message = "Wrong Username or Password";
                }
            }
            catch (Exception ex)
            {
                response.Status = 1;
                response.Message = ex.Message;
            }
            return Json(response);
        }
    }
}