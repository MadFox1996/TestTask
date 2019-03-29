using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.BLL.Interfaces;
using TestTask.BLL.DTO;
using TestTask.BLL.Infrastucture;

namespace TestTask.WEB.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        IProductService ps;

        public ProductController(IProductService serv)
        {
            ps = serv;
        }

        [HttpGet]
        [Authorize(Roles = "user,admin, manager")]
        public JsonResult Get()
        {
            try
            {
                var list = ps.GetProducts();
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
        [Authorize(Roles = "admin, manager")]
        public JsonResult Update(ProductDTO data)
        {
            bool success = false;
            string message = "no record found";
            if (data != null)
            {
                ps.UpdateProduct(data);
                ps.Save();
                success = true;
                message = "Record updated!";
                return Json(new
                {
                    data,
                    success,
                    message
                });
            }
            return Json(new
            {
                data,
                success,
                message
            });
        } 

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public JsonResult Delete(ProductDTO data)
        {
            bool success = false;
            string message = "Error: can't create a record";
            if (data != null)
            {
                ps.Delete(data);
                ps.Save();
                success = true;
                message = "Record Created!";
                return Json(new
                {
                    data,
                    success,
                    message
                });
            }
            return Json(new
            {
                data,
                success,
                message
            });
        }

        [HttpPost]
        [Authorize(Roles = "admin, manager")]
        public JsonResult Create(ProductDTO data)
        {
            bool success = false;
            string message = "Error: can't create a record";
            if (data != null)
            {
                ps.Create(data);
                ps.Save();
                success = true;
                message = "Record Created!";
                return Json(new
                {
                    data,
                    success,
                    message
                });
            }
            return Json(new
            {
                data,
                success,
                message
            });
        }
    }
}
