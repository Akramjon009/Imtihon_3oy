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
        private readonly IProductService _productService;

        public UserService(IUserRepository userRepository, IProductService productService)
        {
            _userRepository = userRepository;
            _productService = productService;
        }


        public async Task<UserModel> CreateUser(UserDTO userDTO)
        {

            if (await Check(userDTO.Email, userDTO.Login))
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


        public async Task<IEnumerable<UserViewModel>> GetAllUser()
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

        public async Task<UserModel> GetUserById(long Id)
        {
            var user = await _userRepository.GetByAny(x => x.Id == Id);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public async Task<UserModel> GetUserByLogin(string login)
        {
            var user = await _userRepository.GetByAny(x => x.Login == login);
            if (user != null)
            {
                return user;
            }
            return null;
        }
        public async Task<UserModel> UpdateUser(long Id, UserDTO userDTO)
        {
            if (await Check(userDTO.Email, userDTO.Login))
            {
                var old = await _userRepository.GetByAny(x => x.Id == Id);


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

        public async Task<UserModel> UpdateUserEmail(long Id, string email)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                if (await Check(email))
                {
                    res.Email = email;
                    var result = await _userRepository.Update(res);

                    return result;
                }
                return new UserModel();
            }
            return new UserModel();
        }

        public async Task<string> UpdateUserOrder(string login, string ProductName, string description)
        {
            if (await _productService.SelProduct(ProductName, description) != null)
            {
                var result = await _userRepository.GetByAny(x => x.Login == login);
                if (result != null)
                {
                    await _userRepository.Update(result);
                    return $"You bought {ProductName}";
                }
                return "Login is wrong";
            }
            return $"Product dosen't exist";
        }

        public async Task<UserModel> UpdateUserLogin(long Id, string login)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                if (await Check(null, login))
                {
                    res.Login = login;
                    var result = await _userRepository.Update(res);

                    return result;
                }
                return new UserModel();
            }
            return new UserModel();
        }

        public async Task<UserModel> UpdateUserName(long Id, string fullname)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                res.FullName = fullname;
                var result = await _userRepository.Update(res);

                return result;
            }
            return new UserModel();
        }

        public async Task<UserModel> UpdateUserPassword(long Id, string password)
        {
            var res = await _userRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {

                res.Password = password;
                var result = await _userRepository.Update(res);

                return result;
            }
            return new UserModel();
        }
        public async Task<bool> DeleteUser(Expression<Func<UserModel, bool>> expression)
        {
            var result = await _userRepository.Delete(expression);

            return result;
        }
        public async Task<UserModel> GetByUserEmail(string email)
        {

            var result = await _userRepository.GetByAny(x => x.Email == email);
            if (result != null)
            {
                return result;
            }
            return null;
        }
        public async Task<bool> Check(string email = null, string login = null)
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
