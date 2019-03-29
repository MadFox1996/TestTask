using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace TestTask.DAL.Entities
{
    public class User : IdentityUser
    {
        public Guid? CustomerID { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
