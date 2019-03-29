using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.DTO;
using TestTask.BLL.Interfaces;
using TestTask.DAL.Entities;
using TestTask.DAL.Interfaces;

namespace TestTask.BLL.Services
{
    public class OrderItemService : IOrderItemService
    {
        IIdentityUnitOfWork Database { get; set; }
        public OrderItemService(IIdentityUnitOfWork uof)
        {
            Database = uof;
        }

        public void Create(OrderItemDTO orderItemDTO)
        {
            var temp = orderItemDTO;
            try
            { 
                OrderItem orderitem = Mapper.Map<OrderItemDTO, OrderItem>(orderItemDTO);

                orderitem.OrderID = orderItemDTO.OrderDTOid;
                orderitem.ProductID = orderItemDTO.ProductDTOid;

                Database.OrderItems.Create(orderitem);
            }
            catch (Exception e)
            {
                string Message = e.Message;
            }
        }

        public void Delete(OrderItemDTO orderItemDTO)
        {
            try
            {
                OrderItem orderItem = Mapper.Map<OrderItemDTO, OrderItem>(orderItemDTO);
                Database.OrderItems.Delete(orderItem);
            }
            catch (Exception e)
            {
                string Message = e.Message;
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public OrderItemDTO GetOrderItem(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderItemDTO> GetOrderItems()
        {
            try
            {       
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<OrderItem, OrderItemDTO>()).CreateMapper();
                

                List<OrderItemDTO> result = new List<OrderItemDTO>();

                foreach (OrderItem item in Database.OrderItems.GetAll().ToList())
                {
                    OrderItemDTO orderItemDTO = mapper.Map<OrderItem, OrderItemDTO>(item);
                    orderItemDTO.OrderDTOid = item.OrderID;
                    orderItemDTO.ProductDTOid = item.ProductID;
                    result.Add(orderItemDTO);
                }
                return result;

            }
            catch (Exception e)
            {
                string Message = e.Message;
                return null;
            }
        }

        public void Save()
        {
            Database.SaveAsync();
        }

        public void UpdateOrderItem(OrderItemDTO orderItemDTO)
        {
            throw new NotImplementedException();
        }
    }
}
