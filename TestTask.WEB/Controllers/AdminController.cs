using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTask.WEB.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult Orders()
        {
            return View();
        }

        public ActionResult Users()
        {
            return View();
        }

    }
}
