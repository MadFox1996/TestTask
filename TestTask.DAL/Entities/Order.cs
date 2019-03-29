using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.DAL.Entities
{
    public class Order
    {
        [Key]
        public Guid ID { get; set; }

        public DateTime ORDER_DATE { get; set; }
        public DateTime? SHIPMENT_DATE { get; set; }
        public int ORDER_NUMBER{get;set;}
        public string status { get; set; }

        //Nav - property
        public Guid? CustomerID { get; set; }
        public virtual Customer Customer { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
