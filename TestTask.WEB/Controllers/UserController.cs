using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestTask.WEB.Controllers
{
    [Authorize(Roles = "user")]
    public class UserController : Controller
    {
        public ActionResult Products()
        {
            return View();
        }

        public ActionResult MyOrders()
        {
            return View();
        }
    }
}
