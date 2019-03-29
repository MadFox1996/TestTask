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
    public class OrderItemController : Controller
    {
        private IOrderItemService orderItemService;

        public OrderItemController(IOrderItemService serv)
        {
            orderItemService = serv;
        }

        [HttpGet]
        [Authorize(Roles = "admin,user, manager")]
        public JsonResult Get()
        {
            try
            {
                var list = orderItemService.GetOrderItems();
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
        [Authorize(Roles = "admin,user, manager")]
        public ActionResult Update(OrderItemDTO orderItemDTO)
        {
            return null;
        }
        [HttpPost]
        [Authorize(Roles = "admin,user, manager")]
        public ActionResult Delete(OrderItemDTO[] orderItemDTO)
        {
            bool success = false;
            string message = "Error: can't create a record";
            if (orderItemDTO != null)
            {
                foreach (var item in orderItemDTO)
                {
                    if(item.OrderDTOid!=null)
                        orderItemService.Delete(item);
                }
                orderItemService.Save();
                success = true;
                message = "Record Deleted!";
                return Json(new
                {
                    orderItemDTO,
                    success,
                    message
                });
            }
            return Json(new
            {
                orderItemDTO,
                success,
                message
            });
        }

        [HttpPost]
        [Authorize(Roles = "admin,user, manager")]
        public JsonResult Create(OrderItemDTO[] orderItemDto)
        {
            bool success = false;
            string message = "Error: can't create a record";
            if (orderItemDto != null)
            {
                foreach (var item in orderItemDto)
                {
                    if(item.OrderDTOid != null)
                        orderItemService.Create(item);
                }
                orderItemService.Save();
                success = true;
                message = "Record Created!";
                return Json(new
                {
                    orderItemDto,
                    success,
                    message
                });
            }
            return Json(new
            {
                orderItemDto,
                success,
                message
            });

        }
    }
}
