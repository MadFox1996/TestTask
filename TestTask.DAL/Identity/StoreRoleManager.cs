using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Entities;

namespace TestTask.DAL.Identity
{
   public class StoreRoleManager:RoleManager<StoreRole>
    {
        public StoreRoleManager(RoleStore<StoreRole> store)
                    : base(store)
        {

        }
    }
}
