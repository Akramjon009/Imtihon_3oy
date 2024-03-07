using OrderManagementAPI.Application.Abstractions.IRepositories;
using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Models;
using OrderManagementAPI.Domen.Entites.ViewModel;
using System.Linq.Expressions;

namespace OrderManagementAPI.Application.Abstractions.IService
{
    public interface IUserService
    {
        public Task<UserModel> CreateUser(UserDTO userDTO,string path);
        public Task<UserViewModel> GetUserById(long Id);
        public Task<UserViewModel> GetUserByLogin(string login);
        public Task<IEnumerable<UserViewModel>> GetAllUser();
        public Task<UserModel> UpdateUser(long Id, string password, UserDTO userDTO);
        public Task<UserModel> UpdateUserName(long Id, string password, string Fullname);
        public Task<string> UpdateUserOrder(string login, string password, string ProductName, string description);
        public Task<UserModel> UpdateUserEmail(long Id, string password, string Email);
        public Task<UserModel> UpdateUserPassword(long Id, string password, string Password);
        public Task<UserModel> UpdateUserLogin(long Id, string password, string login);
        public Task<bool> DeleteUser(long id, string password);
        public Task<string> GetPdfPath();
        public Task<bool> UpdatePhoto(long id,string path);
        public Task<UserModel> InforToken(string login);
        public Task<string> FillUp(long id, string password, long many);
        public Task<string> GetMany(long id, string password);
        public Task<string> GetPicture(string Login);



    }
}
