using OrderManagementAPI.Application.Abstractions.IRepositories;
using OrderManagementAPI.Domen.Entites.Models;
using OrderManagementAPI.Infrostracture.Persistace;


namespace OrderManagementAPI.Infrostracture.Repositories
{
    public class ProdactRepository : BaseRepository<ProductModel>, IProductRepository
    {
        public ProdactRepository(OrderManagmentDbContext context) : base(context)
        {

        }
    }
}
