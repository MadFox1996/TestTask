using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.BLL.DTO
{
    public class OrderDTO
    {
        [Key]
        public Guid id { get; set; }
        public DateTime? ORDER_DATE { get; set; }
        public DateTime? SHIPMENT_DATE { get; set; }
        public int ORDER_NUMBER { get; set; }
        public string status { get; set; }

        public Guid? CustomerDTOid { get; set; }
        public virtual CustomerDTO CustomerDTO { get; set; }
    }
}
