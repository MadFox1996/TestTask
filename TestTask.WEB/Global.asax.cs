using Ninject;
using Ninject.Modules;
using Ninject.Web.Mvc;
using NLayerApp.BLL.Infrastructure;
using TestTask.WEB.Util;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestTask.BLL.Services;
using TestTask.WEB.App_Start;

namespace TestTask.WEB
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfig.Initialize();

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //Утсановлене зависимостей

            NinjectModule productModule = new ProductModule();
            NinjectModule orderModule = new OrderModule();
            NinjectModule customerModule = new CustomerModule();
            NinjectModule orderItemModule = new OrderItemModule();
            NinjectModule userModule = new UserModule();


            NinjectModule serviceModule = new ServiceModule("DefaultConnection");
           
            var kernel = new StandardKernel(
                serviceModule, productModule, 
                orderModule,customerModule,
                orderItemModule,userModule);
           
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
        }
    }
}
