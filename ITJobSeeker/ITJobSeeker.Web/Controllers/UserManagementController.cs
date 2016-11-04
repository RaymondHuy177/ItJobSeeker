using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITJobSeeker.Web.Controllers
{
    public class UserManagementController : Controller
    {
        // GET: UserManagement
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ActiveUser(string id)
        {
            return View();
        }
        public ActionResult DeactiveUser(string id)
        {
            return View();
        }
    }
}