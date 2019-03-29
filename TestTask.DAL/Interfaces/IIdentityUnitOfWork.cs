using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Entities;
using TestTask.DAL.Identity;

namespace TestTask.DAL.Interfaces
{
    public interface IIdentityUnitOfWork
    {
        ICustomerManager CustomerManager { get; }
        StoreUserManager StoreUserManager { get; }
        StoreRoleManager StoreRoleManager { get; }

        IRepository<Product> Products { get; }
        IRepository<Order> Orders { get; }
        IRepository<OrderItem> OrderItems { get; }
        IRepository<Customer> Customers { get; }
        IRepository<User> Users { get; }


        Task SaveAsync();
        void Dispose();
    }
}
