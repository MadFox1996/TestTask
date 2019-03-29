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
    public class CustomerService : ICustomerService
    {
        IIdentityUnitOfWork Database { get; set; }

        public CustomerService(IIdentityUnitOfWork uow)
        {
            Database = uow;
        }

        public void Create(CustomerDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public void Delete(CustomerDTO productDTO)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public CustomerDTO GetProduct(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerDTO> GetCustomers()
        {
            try
            {
                
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Customer, CustomerDTO>()).CreateMapper();
                return mapper.Map<IEnumerable<Customer>, List<CustomerDTO>>(Database.Customers.GetAll());
               
            }
            catch (Exception e)
            {
                string Message = e.Message;
                return null;
            }
        }

        public CustomerDTO GetCustomerById(Guid id)
        {
            return Mapper.Map<Customer, CustomerDTO>(Database.CustomerManager.GetById(id));
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void UpdateProduct(CustomerDTO productDTO)
        {
            throw new NotImplementedException();
        }
    }
}
