using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.Interfaces;
using TestTask.DAL.Entities;
using TestTask.DAL.Interfaces;
using AutoMapper;
using TestTask.BLL.DTO;
using TestTask.BLL.Infrastucture;

namespace TestTask.BLL.Services
{
    public class ProductService:IProductService
    {
        IIdentityUnitOfWork Database { get; set; }
        public ProductService(IIdentityUnitOfWork uof)
        {
            Database = uof;
        }
        public IEnumerable<ProductDTO> GetProducts()
        {
            try
            {
                
                var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Product, ProductDTO>()).CreateMapper();
                return mapper.Map<IEnumerable<Product>, List<ProductDTO>>(Database.Products.GetAll());
                
            }
            catch(Exception e)
            {
                string Message = e.Message;
                return null;
            }
        }
        public ProductDTO GetProduct(Guid id)
        {
            //if (id == null)
            //    throw new ValidationException("Не установлено id", "");
            //var product = Database.Products.Get(100);
            //if (product == null)
            //    throw new ValidationException("Не найдено", "");

            //return new ProductDTO { CODE = product.CODE, id = product.ID, NAME = product.NAME, PRICE = product.PRICE,
            //    CATEGORY = product.CATEGORY };
            return null;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public void UpdateProduct(ProductDTO productDTO)
        {
            try
            {
                Product product = Mapper.Map<ProductDTO, Product>(productDTO);
                Database.Products.Update(product);
            }
            catch (Exception e)
            {
                string Message = e.Message;
            }
        }

        public void Delete(ProductDTO productDTO)
        {
            try
            {
                Product product = Mapper.Map<ProductDTO, Product>(productDTO);
                Database.Products.Delete(product);
            }
            catch (Exception e)
            {
                string Message = e.Message;
            }
        }

        public void Create(ProductDTO productDTO)
        {
            try
            {
                Product product = Mapper.Map<ProductDTO, Product>(productDTO);
                Database.Products.Create(product);
            }
            catch (Exception e)
            {
                string Message = e.Message;
            }
        }

        public void Save()
        {
            Database.SaveAsync();
        }
    }
}
