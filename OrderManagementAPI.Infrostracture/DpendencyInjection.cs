using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderManagementAPI.Infrostracture.Persistace;

namespace OrderManagementAPI.Infrostracture
{
    public static class DpendencyInjection
    {
        public static IServiceCollection AddInfrastracture(this IServiceCollection services, IConfiguration conf)
        {
            services.AddDbContext<OrderManagmentDbContext>(options =>
            {
                options.UseNpgsql(conf.GetConnectionString("OrderConnectionString"));
            });

            return services;
        }

    }
}
