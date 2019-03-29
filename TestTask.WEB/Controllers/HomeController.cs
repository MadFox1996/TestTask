using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.BLL.Services;
using TestTask.BLL.Interfaces;

namespace TestTask.WEB.Controllers
{
    public class HomeController : Controller
    {
        IProductService ps;

        public HomeController(IProductService serv)
        {
            ps = serv;
        }

        public ActionResult Index()
        {
            bool IsAdmin = HttpContext.User.IsInRole("admin");
            bool IsManadger = HttpContext.User.IsInRole("manager");
            bool IsUser = HttpContext.User.IsInRole("user");
            if (IsAdmin)
            {
                return RedirectToAction("Products", "Admin");
            }
            if(IsManadger)
            {
                return RedirectToAction("Products", "Manager");
            }
            if (IsUser)
            {
               return RedirectToAction("Products", "User");
            }
            return RedirectToAction("Login", "Accounts");
        }  
    }
}