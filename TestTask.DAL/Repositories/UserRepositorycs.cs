using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.EF;
using TestTask.DAL.Entities;
using TestTask.DAL.Interfaces;

namespace TestTask.DAL.Repositories
{
    class UserRepository : IRepository<User>
    {
        private DatabaseContext db;

        public UserRepository(DatabaseContext db)
        {
            this.db = db;
        }

        public void Create(User item)
        {
            throw new NotImplementedException();
        }

        public void Delete(User item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> Find(Func<User, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public User Get(Guid id)
        {
            //User result = db.Users.Find(id.ToString());
            string userId = id.ToString();
            User result = db.Users.Find(userId);
            return result;
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Update(User item)
        {
            throw new NotImplementedException();
        }
    }
}
