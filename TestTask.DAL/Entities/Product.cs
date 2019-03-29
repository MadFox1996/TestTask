using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TestTask.DAL.Entities
{
    public class Product
    {
        [Key]
        public Guid ID { get; set; }
        public string CODE { get; set; }
        public string NAME { get; set; }
        public double PRICE { get; set; }
        public string CATEGORY { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
        public Product()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
