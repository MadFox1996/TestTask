using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.EF;
using TestTask.DAL.Entities;
using TestTask.DAL.Identity;
using TestTask.DAL.Interfaces;

namespace TestTask.DAL.Repositories
{
    class CustomerManager:ICustomerManager
    {
        public DatabaseContext Database { get; set; }
        public CustomerManager(DatabaseContext db)
        {
            Database = db;
        }

        public void Create(Customer customer)
        {
            Database.Customers.Add(customer);
            Database.SaveChanges();
        }

        public Customer Get(Customer customer)
        {
            Customer result = Database.Customers.Find(customer.ID);
            return result;
        }
        public Customer GetById(Guid id)
        {
            Customer result = Database.Customers.Find(id);
            return result;
        }

        public void Update(Customer customer)
        {
            Database.Entry(customer).State = EntityState.Modified;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void Delete(Customer customer)
        {
            Database.Customers.Remove(customer);
        }

       
    }
}
