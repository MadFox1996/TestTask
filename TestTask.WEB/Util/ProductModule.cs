using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject.Modules;
using TestTask.BLL.Services;
using TestTask.BLL.Interfaces;

namespace TestTask.WEB.Util
{
    public class ProductModule:NinjectModule
    {
        public override void Load()
        {
            Bind<IProductService>().To<ProductService>();
        }
    }
}