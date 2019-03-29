using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTask.WEB.Controllers
{
    [Authorize(Roles = "manager")]
    public class ManagerController : Controller
    {
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult ProductEditor()
        {
            return View();
        }

        public ActionResult MyOrders()
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