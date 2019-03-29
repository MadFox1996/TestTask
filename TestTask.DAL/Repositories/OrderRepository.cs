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
    public class OrderRepository : IRepository<Order>
    {

        private DatabaseContext db;
        public OrderRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Create(Order item)
        {
            db.Orders.Add(item);
        }

        public void Delete(Order item)
        {
            db.Entry(item).State = EntityState.Deleted;
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return db.Orders.Where(predicate).ToList();
        }

        public Order Get(Guid id)
        {
            return db.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
