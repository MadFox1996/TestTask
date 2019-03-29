using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.BLL.DTO
{
    public class CustomerDTO
    {
        [Key]
        public Guid id { get; set; }
        public string NAME { get; set; }
        public string CODE { get; set; }
        public string ADRESS { get; set; }
        public double DISCOUNT { get; set; }

        public virtual ICollection<OrderDTO> OrderDTOs { get; set; }
        public CustomerDTO()
        {
            OrderDTOs = new List<OrderDTO>();
        }
    }
}
