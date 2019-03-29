using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Interfaces;
using TestTask.DAL.Entities;
using TestTask.DAL.EF;
using System.Data.Entity;

namespace TestTask.DAL.Repositories
{
    class ProductRepository : IRepository<Product>
    {
        private DatabaseContext db;

        public ProductRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Create(Product item)
        {
            db.Products.Add(item);
        }

        public void Delete(Product product)
        {
            db.Entry(product).State = EntityState.Deleted;
        }
      
        public IEnumerable<Product> Find(Func<Product, bool> predicate)
        {
            return db.Products.Where(predicate).ToList();
        }

        public Product Get(Guid id)
        {
            return db.Products.Find(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return db.Products;
        }

        public void Update(Product item)
        {
            try
            {
                db.Entry(item).State = EntityState.Modified;
            }
            catch(Exception e)
            {
                string message = e.Message;
            }
        }
    }
}
