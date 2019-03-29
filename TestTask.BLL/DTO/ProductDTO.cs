using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.BLL.DTO
{
    public class ProductDTO
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        public string CODE { get; set; }
        public string NAME { get; set; }
        public double PRICE { get; set; }
        public string CATEGORY { get; set; }
    }
}
