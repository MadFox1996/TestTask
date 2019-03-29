using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.DTO;

namespace TestTask.BLL.Interfaces
{
    public interface IOrderItemService
    {
        OrderItemDTO GetOrderItem(Guid id);
        void UpdateOrderItem(OrderItemDTO orderItemDTO);

        IEnumerable<OrderItemDTO> GetOrderItems();

        void Delete(OrderItemDTO orderItemDTO);
        void Create(OrderItemDTO orderItemDTO);
        void Dispose();
        void Save();
    }
}
