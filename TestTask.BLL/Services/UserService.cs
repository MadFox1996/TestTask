using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TestTask.BLL.DTO;
using TestTask.BLL.Infrastucture;
using TestTask.BLL.Interfaces;
using TestTask.DAL.Entities;
using TestTask.DAL.Interfaces;
using System.Security.Cryptography;
using System.Web.Helpers;
using AutoMapper;

namespace TestTask.BLL.Services
{
    public class UserService:IUserService
    {
        IIdentityUnitOfWork Database { get; set; }

        public UserService(IIdentityUnitOfWork uow)
        {
            Database = uow;
        }

        public async Task<OperationDetails> Create(UserDTO userDto)
        {
            User user = await Database.StoreUserManager.FindAsync(userDto.UserName, userDto.Password);
            if (user == null)
            {
                user = new User
                {
                    UserName = userDto.UserName
                };
               
                
                var result = await Database.StoreUserManager.CreateAsync(user, userDto.Password);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
                
                await Database.StoreUserManager.AddToRoleAsync(user.Id, userDto.Role);

                if (userDto.Role != "admin")
                {
                    if (userDto.CustomerDTO == null)
                    {
                        Customer customer = new Customer
                        {
                            ID = userDto.id,
                            NAME = userDto.NAME,
                            CODE = userDto.CODE,
                            ADRESS = userDto.ADRESS,
                            DISCOUNT = userDto.DISCOUNT
                        };
                        Database.CustomerManager.Create(customer);
                        user.Customer = customer;
                    }
                    else
                    {
                        Customer customer = new Customer
                        {
                            ID = userDto.CustomerDTO.id,
                            NAME = userDto.CustomerDTO.NAME,
                            CODE = userDto.CustomerDTO.CODE,
                            ADRESS = userDto.CustomerDTO.ADRESS,
                            DISCOUNT = userDto.CustomerDTO.DISCOUNT
                        };
                        Database.CustomerManager.Create(customer);
                        user.Customer = customer;
                    }

                }
                await Database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<OperationDetails> Update(UserDTO userDto)
        {
            User user = await Database.StoreUserManager.FindByIdAsync((userDto.id).ToString());
            if (user != null)
            {
                user.UserName = userDto.UserName;
                var result = await Database.StoreUserManager.UpdateAsync(user);
                if (result.Errors.Count() > 0)
                    return new OperationDetails(false, result.Errors.FirstOrDefault(), "");
              
                await Database.StoreUserManager.AddToRoleAsync(user.Id, userDto.Role);
                

                Customer customer = Database.CustomerManager.Get(user.Customer);

                if (customer != null)
                {
                    customer.NAME = userDto.CustomerDTO.NAME;
                    customer.CODE = customer.CODE.Remove(0, 4);
                    customer.CODE = userDto.CustomerDTO.CODE + customer.CODE;
                    customer.ADRESS = userDto.CustomerDTO.ADRESS;
                    customer.DISCOUNT = userDto.CustomerDTO.DISCOUNT;
                }

                Database.CustomerManager.Update(customer);
                user.Customer = customer;
               
                await Database.SaveAsync();
                return new OperationDetails(true, "Редактирование пользователя прошло успешно", "");
            }
            else
            {
                return new OperationDetails(false, "Такого пользователя не существует", "");
            }
        }

        public async Task<OperationDetails> Delete(UserDTO userDto)
        {
            User user = await Database.StoreUserManager.FindByIdAsync((userDto.id).ToString());
            if (user != null)
            {
                if (user.Customer !=null)
                {
                    Customer customer = Database.CustomerManager.Get(user.Customer);
                    Database.CustomerManager.Delete(customer);
                }
              

                await Database.StoreUserManager.DeleteAsync(user);
                await Database.SaveAsync();
                return new OperationDetails(true, "Редактирование пользователя прошло успешно", "");
            }
            else
            {
                return new OperationDetails(false, "Такого пользователя не существует", "");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {

            ClaimsIdentity claim = null;
            

            User user = await Database.StoreUserManager.FindAsync(userDto.UserName, userDto.Password);
            
            if (user != null)
                claim = await Database.StoreUserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await Database.StoreRoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new StoreRole { Name = roleName };
                    await Database.StoreRoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            try
            {
                var mapper = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<User, UserDTO>().ForMember(
                            dest => dest.CustomerDTO,
                            opt => opt.MapFrom(src => Mapper.Map<Customer, CustomerDTO>(src.Customer)
                            )
                        );
                }
                    ).CreateMapper();


                List<UserDTO> result = new List<UserDTO>();
              

                foreach (User item in Database.Users.GetAll().ToList())
                { 
                    UserDTO userDTO = mapper.Map<User, UserDTO>(item);
                    result.Add(userDTO);
                }

                foreach (var item in result)
                {
                    item.Role = string.Join(",",Database.StoreUserManager.GetRoles((item.id).ToString()).ToArray());
                }
              
                return result;  
            }
            catch (Exception e)
            {
                string Message = e.Message;
                return null;
            } 
        }

        public UserDTO GetById(Guid id)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>().ForMember(
                        dest => dest.CustomerDTO,
                        opt => opt.MapFrom(src => Mapper.Map<Customer, CustomerDTO>(src.Customer)
                        )
                    );
            }
                ).CreateMapper();
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>());
            UserDTO userDTO = mapper.Map<User, UserDTO>(Database.Users.Get(id));
            return userDTO;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        
    }
}
