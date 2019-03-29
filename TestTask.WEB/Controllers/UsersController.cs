using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TestTask.BLL.DTO;
using TestTask.BLL.Infrastucture;
using TestTask.BLL.Interfaces;
using TestTask.BLL.Services;

namespace TestTask.WEB.Controllers
{
    [Authorize(Roles = "admin, manager")]
    public class UsersController : Controller
    {
        IUserService userService;
        public UsersController(IUserService service)
        {
            userService = service;
        }

        [HttpGet]
        public JsonResult Get()
        {
            try
            {
                var list = userService.GetUsers();
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