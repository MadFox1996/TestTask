using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.DAL.Entities
{
    public class OrderItem
    {
        public Guid ID { get; set; }
        public int PRODUCT_COUNTS { get; set; }
        public double PRICE { get; set; }//Высчитывается в клиенте
        
        //Nav properties
        public Guid? OrderID { get; set; }
        public virtual Order Order { get; set; }

        public Guid? ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
