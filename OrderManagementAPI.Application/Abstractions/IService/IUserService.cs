using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Models;
using OrderManagementAPI.Domen.Entites.ViewModel;
using System.Linq.Expressions;

namespace OrderManagementAPI.Application.Abstractions.IService
{
    public interface IUserService
    {
        public Task<UserModel> Create(UserDTO userDTO);
        public Task<UserModel> GetById(long Id);
        public Task<IEnumerable<UserViewModel>> GetAll();
        public Task<UserModel> Update(int Id, UserDTO userDTO);
        public Task<UserModel> UpdateName(int Id, string Fullname);
        public Task<UserModel> UpdateEmail(int Id, string Email);
        public Task<UserModel> UpdatePassword(int Id, string Password);
        public Task<UserModel> UpdateLogin(int Id, string login);
        public Task<bool> Delete(Expression<Func<UserModel, bool>> expression);
    }
}
