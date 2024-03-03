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
        public Task<UserModel> GetByLogin(string login);
        public Task<IEnumerable<UserViewModel>> GetAll();
        public Task<UserModel> Update(long Id, UserDTO userDTO);
        public Task<UserModel> UpdateName(long Id, string Fullname);
        public Task<string> UpdateOrder(string login,string ordername,string discripthin);
        public Task<UserModel> UpdateEmail(long Id, string Email);
        public Task<UserModel> UpdatePassword(long Id, string Password);
        public Task<UserModel> UpdateLogin(long Id, string login);
        public Task<bool> Delete(Expression<Func<UserModel, bool>> expression);
    }
}
