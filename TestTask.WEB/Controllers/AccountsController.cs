using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using TestTask.WEB.Models;
using TestTask.BLL.DTO;
using System.Security.Claims;
using TestTask.BLL.Interfaces;
using TestTask.BLL.Infrastucture;
using System;
using System.Linq;

namespace TestTask.WEB.Controllers
{
    
    public class AccountsController : Controller
    {
        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model)
        {
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
               
                UserDTO userDto = new UserDTO { UserName = model.UserName, Password = model.Password };
               
                ClaimsIdentity claim = await UserService.Authenticate(userDto);
               
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            Random rnd = new Random();
            await SetInitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDto = new UserDTO
                {
                    id = Guid.NewGuid(),
                    NAME = model.Name,
                    UserName=model.UserName,
                    CODE = rnd.Next(1, 9999).ToString()+'-'+ DateTime.Now.Year.ToString(),
                    ADRESS = model.Adress,
                    DISCOUNT=0,
                    Password = model.Password,
                    Role = "user"   
                };
                OperationDetails operationDetails = await UserService.Create(userDto);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public async Task<JsonResult> Create(UserDTO userDTO)
        {
            userDTO.NAME = userDTO.CustomerDTO.NAME;
            userDTO.ADRESS = userDTO.CustomerDTO.ADRESS;
            userDTO.DISCOUNT = userDTO.CustomerDTO.DISCOUNT;
            userDTO.CODE = userDTO.CustomerDTO.CODE;

            if (userDTO.CODE.Length == 0)
            {
                Random rnd = new Random();
                int code = rnd.Next(1, 9999);
                userDTO.CODE = code.ToString("D4") + '-' + DateTime.Now.Year.ToString();
                userDTO.CustomerDTO.CODE = userDTO.CODE;
            }
            else 
            {
                userDTO.CODE = userDTO.CODE + '-' + DateTime.Now.Year.ToString();
                userDTO.CustomerDTO.CODE = userDTO.CODE;
            }

            OperationDetails operationDetails = await UserService.Create(userDTO);
            if (operationDetails.Succedeed)
            {
                return this.Json(new { success = false, data = "" }, JsonRequestBehavior.AllowGet);
            }
            else
                ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return this.Json(new { success = false, data = "" }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Authorize(Roles = "admin, manager")]
        public JsonResult Get()
        {
            try
            {
                var list = UserService.GetUsers();
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

        [HttpGet]
        [Authorize(Roles = "manager")]
        public JsonResult GetForManager()
        {
            try
            {
                var list = UserService.GetUsers();

                var selectedUsers = from user in list
                                     where user.Role != "admin"
                                     select user;

                return this.Json(
                    new
                    {
                        data = selectedUsers
                    },
                    JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return this.Json(new { success = false, data = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public async Task<JsonResult> Update(UserDTO userDTO)
        {
            OperationDetails operationDetails = await UserService.Update(userDTO);
            if (operationDetails.Succedeed)
            {
                return this.Json(new { success = false, data = "" }, JsonRequestBehavior.AllowGet);
            }
            else
                ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return this.Json(new { success = false, data = "" }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public async Task<JsonResult> Delete(UserDTO userDTO)
        {
            OperationDetails operationDetails = await UserService.Delete(userDTO);
            if (operationDetails.Succedeed)
            {
                return this.Json(new { success = false, data = "" }, JsonRequestBehavior.AllowGet);
            }
            else
                ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            return this.Json(new { success = false, data = "" }, JsonRequestBehavior.AllowGet);
        }

        private async Task SetInitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                id = Guid.NewGuid(),
                Password = "qwe123!",
                NAME = "Durov",
                UserName = "Admin",
                ADRESS = "Dubay",
                Role = "admin",
                CODE = DateTime.Now.ToString()
            }, new List<string> { "user", "admin","manager" });
        }
    }
}
