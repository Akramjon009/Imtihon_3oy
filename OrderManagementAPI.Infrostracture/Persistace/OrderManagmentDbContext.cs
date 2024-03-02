using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Domen.Entites.Models;

namespace OrderManagementAPI.Infrostracture.Persistace
{
    public class OrderManagmentDbContext: DbContext
    {
        public OrderManagmentDbContext(DbContextOptions<OrderManagmentDbContext> option)
            :base(option)
        { 
        }
        public virtual DbSet<UserModel> Users { get; set; }
        public virtual DbSet<ProductModel> Product {  get; set; }
    }
}
