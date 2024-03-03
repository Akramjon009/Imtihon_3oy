using FutureProjects.Domain.Entities.DTOs;

namespace OrderManagementAPI.Application.Abstractions.IService
{
    public interface IAuthService
    {
        public Task<ResponseLogin> GenerateToken(RequestLogin user);
    }
}
