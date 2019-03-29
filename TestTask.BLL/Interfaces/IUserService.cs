using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.DTO;
using TestTask.BLL.Infrastucture;
using TestTask.DAL.Entities;

namespace TestTask.BLL.Interfaces
{
    public interface IUserService:IDisposable
    {
        Task<OperationDetails> Create(UserDTO userDTO);
        Task<OperationDetails> Update(UserDTO userDTO);
        Task<OperationDetails> Delete(UserDTO userDTO);
        IEnumerable<UserDTO> GetUsers();
        UserDTO GetById(Guid id);

        Task<ClaimsIdentity> Authenticate(UserDTO userDTO);
        Task SetInitialData(UserDTO adminDTO, List<string> roles);
        
    }
}
