using ITJobSeeker.Model.Models;
using ITJobSeeker.Service.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITJobSeeker.Web.Controllers
{
    public class AdminController : Controller
    {
        private readonly IJobService jobService;

        public AdminController(IJobService _jobService)
        {
            jobService = _jobService;
        }
        // GET: Admin
        public ActionResult AllJobs(int page = 1)
        {
            IEnumerable<Job> jobs = jobService.GetJobsByPage(page);
            return View(jobs);
        }

        public JsonResult DeActiveJob(string jobID)
        {
            StandardResponse response = new StandardResponse();
            try
            {
                Job job = jobService.GetDetailJob(new Guid(jobID));
                job.IsActive = false;
                jobService.SaveJob();
            }
            catch (Exception ex)
            {
                response.Status = 1;
                response.Message = ex.Message;
            }
            return Json(response);
        }

        public JsonResult ActiveJob(string jobID)
        {
            StandardResponse response = new StandardResponse();
            try
            {
                Job job = jobService.GetDetailJob(new Guid(jobID));
                job.IsActive = true;
                jobService.SaveJob();
            }
            catch (Exception ex)
            {
                response.Status = 1;
                response.Message = ex.Message;
            }
            return Json(response);
        }

        public JsonResult DeleteJob(string jobID)
        {
            StandardResponse response = new StandardResponse();
            try
            {
                Job job = jobService.GetDetailJob(new Guid(jobID));
                jobService.DeleteJob(job);
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