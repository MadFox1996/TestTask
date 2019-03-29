using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.DTO;
using TestTask.DAL.Entities;

namespace TestTask.BLL.Config
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<OrderItemDTO, OrderItem>();
                cfg.CreateMap<OrderDTO, Order>();
                cfg.CreateMap<ProductDTO, Product>();
                cfg.CreateMap<CustomerDTO, Customer>();
                cfg.CreateMap<UserDTO, User>();
                cfg.CreateMap<Customer, CustomerDTO>();
            }
            );
        }
    }
}
