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
    class OrderItemRepository : IRepository<OrderItem>
    {
        private DatabaseContext db;

        public OrderItemRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Create(OrderItem item)
        {
            db.OrderItems.Add(item);
        }

        public void Delete(OrderItem item)
        {
            db.Entry(item).State = EntityState.Deleted;
        }

        public IEnumerable<OrderItem> Find(Func<OrderItem, bool> predicate)
        {
            return db.OrderItems.Where(predicate).ToList();
        }

        public OrderItem Get(Guid id)
        {
            return db.OrderItems.Find(id);
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return db.OrderItems;
        }

        public void Update(OrderItem item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
