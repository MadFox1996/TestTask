using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.BLL.DTO
{
    public class UserDTO
    {
        [Key]
        public Guid id { get; set; }
        public string NAME { get; set; }
        public string UserName { get; set; }
        public string CODE { get; set; }
        public string ADRESS { get; set; }
        public double DISCOUNT { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        
        public Guid? CustomerDTOid { get; set; }
        public virtual CustomerDTO CustomerDTO { get; set; }
    }
}
