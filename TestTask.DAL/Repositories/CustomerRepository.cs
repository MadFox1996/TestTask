using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.EF;
using TestTask.DAL.Entities;
using TestTask.DAL.Interfaces;

namespace TestTask.DAL.Repositories
{
    class CustomerRepository : IRepository<Customer>
    {
        private DatabaseContext db;

        public CustomerRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Create(Customer item)
        {
            db.Customers.Add(item);
        }

        public void Delete(Customer item)
        {
            Customer customer = db.Customers.Find(item.ID);
            if (customer != null)
                db.Customers.Remove(customer);
        }

        public IEnumerable<Customer> Find(Func<Customer, bool> predicate)
        {
            return db.Customers.Where(predicate).ToList();
        }

        public Customer Get(Guid id)
        {
            return db.Customers.Find(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return db.Customers;
        }

        public void Update(Customer item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
