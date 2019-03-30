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
    public class OrderService : IOrderService
    {
        IIdentityUnitOfWork Database { get; set; }
        public OrderService(IIdentityUnitOfWork uof)
        {
            Database = uof;
        }

        public void Create(OrderDTO orderDTO)
        {
            try
            { 
                Order order = Mapper.Map<OrderDTO, Order>(orderDTO);
                order.CustomerID = orderDTO.CustomerDTO.id;
                //order.Customer = Mapper.Map<CustomerDTO, Customer>(orderDTO.CustomerDTO);
                Database.Orders.Create(order);
            }
            catch (Exception e)
            {
                string Message = e.Message;
            }
        }

        public void Delete(OrderDTO orderDTO)
        {
            try
            {
                Order order = Mapper.Map<OrderDTO, Order>(orderDTO);
                Database.Orders.Delete(order);
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

        public OrderDTO GetProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<OrderDTO> GetProducts()
        {
            try
            {               
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDTO>()).CreateMapper();
                
                List<OrderDTO> result = new List<OrderDTO>();

                //foreach (Order item in Database.Orders.GetAll().ToList())
                //{
                //    OrderDTO orderDTO = mapper.Map<Order, OrderDTO>(item);
                //    orderDTO.CustomerDTOid = item.CustomerID;
                //    result.Add(orderDTO);
                //}

                for (int i = 0; i < Database.Orders.GetAll().ToArray().Length; i++)
                {
                    OrderDTO orderDTO = mapper.Map<Order, OrderDTO>(Database.Orders.GetAll().ToArray()[i]);
                    var item = Database.Orders.GetAll().ToArray()[i];
                    var id = item.CustomerID;
                    orderDTO.CustomerDTOid = id;
                    result.Add(orderDTO);
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

        public void UpdateProduct(OrderDTO orderDTO)
        {
            try
            {
                Order order = Mapper.Map<OrderDTO, Order>(orderDTO);
                order.CustomerID = orderDTO.CustomerDTOid;
                Database.Orders.Update(order);
            }
            catch (Exception e)
            {
                string Message = e.Message;
            }
        }
    }
}
