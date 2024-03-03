using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagementAPI.Application.Abstractions.IRepositories;
using OrderManagementAPI.Infrostracture.Persistace;
using OrderManagementAPI.Infrostracture.Repositories;

namespace OrderManagementAPI.Infrostracture
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastracture(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<OrderManagmentDbContext>(options =>
            {
                options.UseNpgsql(conf.GetConnectionString("OrderConnectionString"), b => b.MigrationsAssembly("OrderManagementAPI.Infrostracture"));
            });



            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, ProdactRepository>();
            return services;
        }

    }
}
