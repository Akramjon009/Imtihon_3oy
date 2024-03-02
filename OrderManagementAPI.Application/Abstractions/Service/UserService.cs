using OrderManagementAPI.Application.Abstractions.IRepositories;
using OrderManagementAPI.Application.Abstractions.IService;
using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Models;
using OrderManagementAPI.Domen.Entites.ViewModel;
using System.Linq.Expressions;

namespace OrderManagementAPI.Application.Abstractions.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserModel> Create(UserDTO userDTO)
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
            var result = await _userRepository.GetByAny(x => x.Id == Id);
            return result;
        }
        public async Task<UserModel> Update(int Id, UserDTO userDTO)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                var user = new UserModel()
                {
                    FullName = userDTO.FullName,
                    Email = userDTO.Email,
                    Login = userDTO.Login,
                    Password = userDTO.Password,
                    Role = userDTO.Role
                };
                var result = await _userRepository.Update(user);

                return result;
            }
            return new UserModel();

        }

        public async Task<UserModel> UpdateEmail(int Id, string email)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
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

        public async Task<UserModel> UpdateLogin(int Id, string longin)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                var user = new UserModel()
                {
                    Login = longin
                };
                var result = await _userRepository.Update(user);

                return result;
            }
            return new UserModel();
        }

        public async Task<UserModel> UpdateName(int Id, string fullname)
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

        public async Task<UserModel> UpdatePassword(int Id, string password)
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
    }
}
