using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.BLL.DTO
{
    public class OrderItemDTO
    {
        [Key]
        public Guid id { get; set; }
        public int PRODUCT_COUNTS { get; set; }
        public double PRICE { get; set; }

       
        public Guid? OrderDTOid { get; set; }
        public  OrderDTO OrderDTO { get; set; }

        public Guid? ProductDTOid { get; set; }
        public ProductDTO ProductDTO { get; set; }
    }
}
