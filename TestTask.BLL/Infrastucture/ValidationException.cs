using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.BLL.Infrastucture
{
    class ValidationException:Exception
    {
        public string Property { get; protected set; }
        public ValidationException(string Message,string prop):base(Message)
        {
            Property = prop;
        }
    }
}
