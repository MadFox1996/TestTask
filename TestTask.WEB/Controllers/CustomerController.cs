using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.BLL.Interfaces;

namespace TestTask.WEB.Controllers
{
    [Authorize(Roles = "admin, manager")]
    public class CustomerController : Controller
    {
        ICustomerService customerService;

        public CustomerController(ICustomerService serv)
        {
            customerService = serv;
        }

        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                var list = customerService.GetCustomers();
                return this.Json(
                    new
                    {
                        data = list
                    },
                    JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return this.Json(new { success = false, data = "" }, JsonRequestBehavior.AllowGet);
            }
        }
        public ActionResult Create()
        {
            return null;
        }
        public ActionResult Update()
        {
            return null;
        }
        public ActionResult Delete()
        {
            return null;
        }
    }
}
