using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.DTO;

namespace TestTask.BLL.Interfaces
{
    public interface IOrderService
    {
        OrderDTO GetProduct(Guid id);
        void UpdateProduct(OrderDTO orderDTO);

        IEnumerable<OrderDTO> GetProducts();

        void Delete(OrderDTO orderDTO);
        void Create(OrderDTO orderDTO);
        void Dispose();
        void Save();
    }
}
