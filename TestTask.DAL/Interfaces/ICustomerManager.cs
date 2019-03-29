using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.DAL.Entities;

namespace TestTask.DAL.Interfaces
{
    
    public interface ICustomerManager:IDisposable
    {
        void Delete(Customer customer);
        void Create(Customer customer);
        void Update(Customer customer);
        Customer Get(Customer customer);
        Customer GetById(Guid id);
    }
}
