using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using OrderManagementAPI.Application.Abstractions.IRepositories;
using OrderManagementAPI.Application.Abstractions.IService;
using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Models;
using OrderManagementAPI.Domen.Entites.ViewModel;
using System.Linq.Expressions;
using System.Text;

namespace OrderManagementAPI.Application.Abstractions.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IProductService _productService;

        public UserService(IUserRepository userRepository, IProductService productService)
        {
            _userRepository = userRepository;
            _productService = productService;
        }

        public async Task<UserModel> Create(UserDTO userDTO)
        {
            var n = Check(userDTO.Email, userDTO.Login);
            if (await n)
            {
                var user = new UserModel()
                {
                    FullName = userDTO.FullName,
                    Email = userDTO.Email,
                    Login = userDTO.Login,
                    Password = userDTO.Password,
                    Role = userDTO.Role,
                };
                var result = await _userRepository.Create(user);

                return result;
            }
            return new UserModel();

        }


        public async Task<IEnumerable<UserViewModel>> GetAll()
        {
            var users = await _userRepository.GetAll();

            var result = users.Select(model => new UserViewModel
            {
                Name = model.FullName,
                Email = model.Email,
                Role = model.Role,
            });

            return result;
        }

        public async Task<UserModel> GetById(long Id)
        {
            var user = await _userRepository.GetByAny(x => x.Id == Id);
            if (user != null)
            {


                return user;
            }
            return null;
        }
        public async Task<UserModel> GetByLogin(string login)
        {
            var user = await _userRepository.GetByAny(x => x.Login == login);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public async Task<UserModel> Update(long Id, UserDTO userDTO)
        {
            if (GetByEmail(userDTO.Email).ToString() == "null" && GetByLogin(userDTO.Login).ToString() == "null")
            {
                var old = await _userRepository.GetByAny(x=>x.Id == Id);


                old.FullName = userDTO.FullName;
                old.Email = userDTO.Email;
                old.Login = userDTO.Login;
                old.Password = userDTO.Password;
                old.Role = userDTO.Role;
                
                var result = await _userRepository.Update(old);

                return result;
            }
            return new UserModel();

        }

        public async Task<UserModel> UpdateEmail(long Id, string email)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                if (GetByEmail(res.Email) == null)
                {
                    var user = new UserModel()
                    {
                        Email = email
                    };
                    var result = await _userRepository.Update(user);

                    return result;
                }
                return new UserModel();
            }
            return new UserModel();
        }

        public async Task<string> UpdateOrder(string productname)
        {
            if (await _productService.UpdateCountByName(productname) != new ProductModel())
            {
                return $"You bought {productname}";
            }
            return $"Product dosen't exist";
        }

        public async Task<UserModel> UpdateLogin(long Id, string login)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                if (GetByLogin(login) == null)
                {
                    var user = new UserModel()
                    {
                        Login = login
                    };
                    var result = await _userRepository.Update(user);

                    return result;
                }
                return new UserModel();
            }
            return new UserModel();
        }

        public async Task<UserModel> UpdateName(long Id, string fullname)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                var user = new UserModel()
                {
                    FullName = fullname
                };
                var result = await _userRepository.Update(user);

                return result;
            }
            return new UserModel();
        }

        public async Task<UserModel> UpdatePassword(long Id, string password)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                var user = new UserModel()
                {
                    Password = password
                };
                var result = await _userRepository.Update(user);

                return result;
            }
            return new UserModel();
        }
        public async Task<bool> Delete(Expression<Func<UserModel, bool>> expression)
        {
            var result = await _userRepository.Delete(expression);

            return result;
        }
        public async Task<UserModel> GetByEmail(string email)
        {
            
            var result = await _userRepository.GetByAny(x => x.Email == email);
            if (result != null) 
            {
                return result;
            }
            return null;
        }
        public async Task<bool> Check(string email, string login) 
        {
            var result = await _userRepository.GetByAny(x => x.Email == email || x.Login == login);
            if (result != null) 
            {
                return false;
            }
            return true;

        }
    }
}
