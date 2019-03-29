using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Entities;

namespace TestTask.DAL.Identity
{
    public class StoreUserManager:UserManager<User>
    {
        public StoreUserManager(IUserStore<User> store)
                : base(store)
        {

        }
    }
}
