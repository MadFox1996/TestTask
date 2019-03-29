using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.DTO;

namespace TestTask.BLL.Interfaces
{
    public interface ICustomerService
    {
        CustomerDTO GetProduct(Guid id);
        void UpdateProduct(CustomerDTO productDTO);

        IEnumerable<CustomerDTO> GetCustomers();

        void Delete(CustomerDTO productDTO);
        void Create(CustomerDTO productDTO);
        CustomerDTO GetCustomerById(Guid id);
        void Dispose();
        void Save();
    }
}
