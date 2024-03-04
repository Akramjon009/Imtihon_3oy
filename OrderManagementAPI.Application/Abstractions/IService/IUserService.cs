using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Models;
using OrderManagementAPI.Domen.Entites.ViewModel;
using System.Linq.Expressions;

namespace OrderManagementAPI.Application.Abstractions.IService
{
    public interface IUserService
    {
        public Task<UserModel> CreateUser(UserDTO userDTO,string path);
        public Task<UserModel> GetUserById(long Id);
        public Task<UserModel> GetUserByLogin(string login);
        public Task<IEnumerable<UserViewModel>> GetAllUser();
        public Task<UserModel> UpdateUser(long Id, UserDTO userDTO);
        public Task<UserModel> UpdateUserName(long Id, string Fullname);
        public Task<string> UpdateUserOrder(string login, string ordername, string discripthin);
        public Task<UserModel> UpdateUserEmail(long Id, string Email);
        public Task<UserModel> UpdateUserPassword(long Id, string Password);
        public Task<UserModel> UpdateUserLogin(long Id, string login);
        public Task<bool> DeleteUser(Expression<Func<UserModel, bool>> expression);
        public Task<string> GetPdfPath();
        public Task<bool> UpdatePhoto(long id,string path);
    }
}
