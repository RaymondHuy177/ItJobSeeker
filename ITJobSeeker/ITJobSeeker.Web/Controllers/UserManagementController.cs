using ITJobSeeker.Model.Models;
using ITJobSeeker.Service.ServiceInterfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITJobSeeker.Web.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IUserService userService;

        public UserManagementController(IUserService _userService)
        {
            userService = _userService;
        }
        // GET: UserManagement
        public ActionResult JobSeekers()
        {
            IEnumerable<User> users = userService.GetAllJobSeekerGridView();
            return View(users);
        }

        public ActionResult Recruiters()
        {
            IEnumerable<User> users = userService.GetAllRecruiterGridView();
            return View(users);
        }
        [HttpPost]
        public JsonResult ActiveUser(string id)
        {
            StandardResponse response = new StandardResponse();
            userService.UpdateActiveStatus(id, true);
            return Json(response);
        }
        [HttpPost]
        public JsonResult DeActiveUser(string id)
        {
            StandardResponse response = new StandardResponse();
            userService.UpdateActiveStatus(id, false);
            return Json(response);
        }
    }
}