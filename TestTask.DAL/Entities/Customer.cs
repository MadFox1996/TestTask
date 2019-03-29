using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.DAL.Entities
{
   public class Customer
    {
        public Guid ID { get; set; }
        public string NAME { get; set; }
        public string CODE { get; set; }
        public string ADRESS { get; set; }
        public double DISCOUNT { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public Customer()
        {
            Orders = new List<Order>();
        }
    }
}