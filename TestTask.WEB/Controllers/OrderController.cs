using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.BLL.DTO;
using TestTask.BLL.Interfaces;

namespace TestTask.WEB.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        IOrderService orderservice;
        ICustomerService customerservice;
        IUserService userService;
        public OrderController(IOrderService orderservice, ICustomerService customerservice, IUserService userService)
        {
            this.orderservice = orderservice;
            this.customerservice = customerservice;
            this.userService = userService;
        }

        [HttpGet]
        [Authorize(Roles = "user, manager")]
        public JsonResult GetByUser()
        {
            Guid id = Guid.Parse((User.Identity.GetUserId()));
            UserDTO userDTO = userService.GetById(id);
            try
            {
                var list = orderservice.GetProducts();
                var selectedOrders = from order in list
                                     where order.CustomerDTOid == userDTO.CustomerDTO.id
                                     select order;
                return this.Json(
                    new
                    {
                        data = selectedOrders
                    },
                    JsonRequestBehavior.AllowGet);
            }
            catch
            {
                return this.Json(new { success = false, data = "" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        [Authorize(Roles = "admin, user, manager")]
        public JsonResult Get()
        {
                try
                {
                    var list = orderservice.GetProducts();
                   
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
        [HttpPost]
        [Authorize(Roles = "user, manager,admin")]
        public ActionResult Update(OrderDTO[] orderDTO)
        {
            bool success = false;
            string message = "no record found";
            if (orderDTO != null)
            {
                foreach (var item in orderDTO)
                {
                    orderservice.UpdateProduct(item);
                }
                orderservice.Save();
                success = true;
                message = "Record updated!";
                return Json(new
                {
                    orderDTO,
                    success,
                    message
                });
            }
            return Json(new
            {
                orderDTO,
                success,
                message
            });
        }
        [HttpPost]
        [Authorize(Roles = "user, manager")]
        public ActionResult Delete(OrderDTO[] orderDTO)
        {
            bool success = false;
            string message = "Error: can't create a record";
            if (orderDTO != null)
            {
                foreach (var item in orderDTO)
                {
                    orderservice.Delete(item);
                }
                orderservice.Save();
                success = true;
                message = "Record Created!";
                return Json(new
                {
                    orderDTO,
                    success,
                    message
                });
            }
            return Json(new
            {
                orderDTO,
                success,
                message
            });
        }
        [HttpPost]
        [Authorize(Roles = "user, manager")]
        public JsonResult Create(OrderDTO[] orderDto)
        {
            Guid id = Guid.Parse((User.Identity.GetUserId()));
           
            UserDTO userDTO = userService.GetById(id);
           
            //orderDto.CustomerDTO = userDTO.CustomerDTO;
            //orderDto.ORDER_DATE = DateTime.Now.ToUniversalTime();

            bool success = false;
            string message = "Error: can't create a record";
            if (orderDto != null)
            {
               
                for (int i = 0; i < orderDto.Count(); i++)
                {
                    orderDto[i].CustomerDTO = userDTO.CustomerDTO;
                    orderDto[i].CustomerDTOid = userDTO.CustomerDTOid;
                    orderDto[i].ORDER_DATE = DateTime.Now.ToUniversalTime();
                    orderservice.Create(orderDto[i]);
                }
               
                orderservice.Save();
                success = true;
                message = "Record Created!";
                return Json(new
                {
                    orderDto,
                    success,
                    message
                });
            }
            return Json(new
            {
                orderDto,
                success,
                message
            });

        }
    }
}
