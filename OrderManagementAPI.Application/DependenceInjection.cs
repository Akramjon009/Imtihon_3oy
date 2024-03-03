using Microsoft.Extensions.DependencyInjection;
using OrderManagementAPI.Application.Abstractions.IService;
using OrderManagementAPI.Application.Abstractions.Service;
using OrderManagementAPI.Application.Abstractions.Service.AuthService;


namespace OrderManagementAPI.Application
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
            return services;
        }
    }
}
