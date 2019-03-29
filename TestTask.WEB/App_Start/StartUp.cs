using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using TestTask.BLL.Services;
using Microsoft.AspNet.Identity;
using TestTask.BLL.Interfaces;


[assembly: OwinStartup(typeof(TestTask.WEB.App_Start.Startup))]

namespace TestTask.WEB.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<IUserService>(CreateUserService);
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                //LoginPath = new PathString("/Accounts/Login"),
                LoginPath = new PathString("/Home/Index"),
            });
        }
        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }
    }
}