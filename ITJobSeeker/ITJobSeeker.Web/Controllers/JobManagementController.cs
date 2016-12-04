using AutoMapper;
using ITJobSeeker.Model.Models;
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
    public class JobManagementController : Controller
    {
        private readonly ITechnologyKeywordService techKeyWordService;
        private readonly IJobService jobService;

        public JobManagementController(ITechnologyKeywordService _techKeyWordService, IJobService _jobService)
        {
            techKeyWordService = _techKeyWordService;
            jobService = _jobService;
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
            try
            {
                var job = Mapper.Map<FormCreateJobViewModel, Job>(formVM);
                job.CompanyID = new Guid("308dc584-e28e-4b5c-bb5c-90e622a73837");
                jobService.AddJob(job);
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
        public ActionResult JobDetail(string id)
        {
            return View();
        }
    }
}