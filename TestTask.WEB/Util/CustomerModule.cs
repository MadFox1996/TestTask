using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.BLL.Interfaces;
using TestTask.BLL.Services;

namespace TestTask.WEB.Util
{
    public class CustomerModule : NinjectModule
    {
        public override void Load()
        {
            Bind<ICustomerService>().To<CustomerService>();
        }
    }
}