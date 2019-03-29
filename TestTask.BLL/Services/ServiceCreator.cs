using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.Interfaces;
using TestTask.DAL.Interfaces;
using TestTask.DAL.Repositories;

namespace TestTask.BLL.Services
{
    public class ServiceCreator:IServiceCreator
    {
        public IUserService CreateUserService(string connection)
        {
            return new UserService(new IdentityUserUnitOfWork(connection));
        }
    }
}
