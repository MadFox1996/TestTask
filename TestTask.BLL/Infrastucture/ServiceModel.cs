using Ninject.Modules;
using TestTask.DAL.Interfaces;
using TestTask.DAL.Repositories;

namespace NLayerApp.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private string connectionString;
        public ServiceModule(string connection)
        {
            connectionString = connection;
        }
        public override void Load()
        {
            Bind<IIdentityUnitOfWork>().To<IdentityUserUnitOfWork>().WithConstructorArgument(connectionString);
        }
    }
}