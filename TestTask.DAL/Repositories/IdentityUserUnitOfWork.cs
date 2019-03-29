using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.EF;
using TestTask.DAL.Entities;
using TestTask.DAL.Identity;
using TestTask.DAL.Interfaces;

namespace TestTask.DAL.Repositories
{
   public class IdentityUserUnitOfWork:IIdentityUnitOfWork
    {
        private DatabaseContext db;

        private StoreUserManager userManager;
        private StoreRoleManager roleManager;
        private ICustomerManager clientManager;

        private ProductRepository productRepository;
        private CustomerRepository customerRepository;
        private OrderRepository orderRepository;
        private OrderItemRepository orderItemRepository;
        private UserRepository userRepository;

        public IdentityUserUnitOfWork(string connectionString)
        {
            db = new DatabaseContext(connectionString);
            userManager = new StoreUserManager(new UserStore<User>(db));
            roleManager = new StoreRoleManager(new RoleStore<StoreRole>(db));
            clientManager = new CustomerManager(db);
        }

        public StoreUserManager StoreUserManager
        {
            get { return userManager; }
        }

        public ICustomerManager CustomerManager
        {
            get { return clientManager; }
        }

        public StoreRoleManager StoreRoleManager
        {
            get { return roleManager; }
        }

        public IRepository<Product> Products
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(db);
                return productRepository;
            }
        }
        public IRepository<Customer> Customers
        {
            get
            {
                if (customerRepository == null)
                    customerRepository = new CustomerRepository(db);
                return customerRepository;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IRepository<OrderItem> OrderItems
        {
            get
            {
                if (orderItemRepository == null)
                    orderItemRepository = new OrderItemRepository(db);
                return orderItemRepository;
            }
        }

        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);
                return userRepository;
            }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}

