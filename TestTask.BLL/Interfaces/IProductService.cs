using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.DTO;

namespace TestTask.BLL.Interfaces
{
    public interface IProductService
    {
        ProductDTO GetProduct(Guid id);
        void UpdateProduct(ProductDTO productDTO);

        IEnumerable<ProductDTO> GetProducts();
       
        void Delete(ProductDTO productDTO);
        void Create(ProductDTO productDTO);
        void Dispose();
        void Save();
    }
}
