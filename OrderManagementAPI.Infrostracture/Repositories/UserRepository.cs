using OrderManagementAPI.Application.Abstractions.IRepositories;
using OrderManagementAPI.Domen.Entites.Models;
using OrderManagementAPI.Infrostracture.Persistace;

namespace OrderManagementAPI.Infrostracture.Repositories
{
    public class UserRepository : BaseRepository<UserModel>, IUserRepository
    {
        public UserRepository(OrderManagmentDbContext context) : base(context)
        { 
        }
    }
}
