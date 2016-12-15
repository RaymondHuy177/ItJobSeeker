using AutoMapper;
using ITJobSeeker.Model.Models;
using ITJobSeeker.Service.Common;
using ITJobSeeker.Service.ServiceInterfaces;
using ITJobSeeker.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITJobSeeker.Web.Controllers
{
    public class RecruiterController : Controller
    {
        private readonly ITechnologyKeywordService techKeyWordService;
        private readonly IJobService jobService;
        private readonly IUserService userService;
        private readonly ICompanyService companyService;

        public RecruiterController(
            ITechnologyKeywordService _techKeyWordService,
            IUserService _userService,
            IJobService _jobService,
            ICompanyService _companyService)
        {
            userService = _userService;
            techKeyWordService = _techKeyWordService;
            jobService = _jobService;
            companyService = _companyService;
        }

        public ActionResult JobRecruiterGridView()
        {
            Guid id = new Guid("308dc584-e28e-4b5c-bb5c-90e622a73837");
            JobRecruiterGridView vm = new JobRecruiterGridView();
            vm.PrepareViewModel(jobService.GetJobsByRecruiter(id));
            return View(vm);
        }

        // GET: JobManagement
        public ActionResult CreateJob()
        {
            FormCreateJobViewModel formVM = new FormCreateJobViewModel();
            formVM.PrepareViewModel(techKeyWordService.GetAllKeywords());
            return View(formVM);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateJob(FormCreateJobViewModel formVM)
        {
            StandardResponse response = new StandardResponse();
            Account account = (Account)Session["Account"];
            try
            {
                var job = Mapper.Map<FormCreateJobViewModel, Job>(formVM);
                job.CompanyID = new Guid(account.ID);
                jobService.AddJob(job);
                response.Message = "Insert Successfully";
            }
            catch (Exception ex)
            {
                response.Status = 1;
                response.Message = ex.Message;
            }
            return Json(response);
        }

        public ActionResult ActiveJob(string id)
        {
            return View();
        }
        public ActionResult DeactiveJob(string id)
        {
            return View();
        }
        public ActionResult EditJob(string jobID)
        {
            Job job = jobService.GetDetailJob(new Guid(jobID));
            FormEditJobViewModel vm = new FormEditJobViewModel();
            vm.PrepareViewModel(techKeyWordService.GetAllKeywords(), job);
            return View(vm);
        }
        [HttpPost]
        public ActionResult EditJob(FormEditJobViewModel formVM)
        {
            StandardResponse response = new StandardResponse();
            try
            {
                var job = Mapper.Map<FormEditJobViewModel, Job>(formVM);
                jobService.EditJob(job);
                response.Message = "Update Successfully";
            }
            catch (Exception ex)
            {
                response.Status = 1;
                response.Message = ex.Message;
            }
            return Json(response);
        }

        public ActionResult ProfilePage()
        {
            Account account = (Account)Session["Account"];
            User user = userService.GetUserInfo(new Guid(account.ID));
            return View(user);
        }

        [HttpPost]
        public ActionResult UpdateProfile(ProfilePageViewModel profile)
        {
            var company = Mapper.Map<ProfilePageViewModel, Company>(profile);
            companyService.UpdateRecruiterInfo(company, profile.FirstPicture, profile.SecondPicture, profile.ThirdPicture, profile.Avatar);
            //Account account = (Account)Session["Account"];
            return Json("");
        }
    }
}