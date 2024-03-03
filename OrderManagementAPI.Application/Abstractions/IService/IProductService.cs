using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Models;
using System.Linq.Expressions;

namespace OrderManagementAPI.Application.Abstractions.IService
{
    public interface IProductService
    {
        public Task<ProductModel> Create(ProductDTO productDTO);
        public Task<ProductModel> GetById(long Id);
        public Task<IEnumerable<ProductDTO>> GetAll();
        public Task<ProductModel> UpdateCountById(long id, long count);
        public Task<ProductModel> SelProduct(string Name, string description);
        public Task<ProductModel> Update(long Id, ProductDTO productDTO);
        public Task<ProductModel> UpdateName(long Id, string Name);
        public Task<ProductModel> UpdateDescription(long Id, string description);
        public Task<ProductModel> UpdateCaunt(long Id, long caunt);
        public Task<bool> Delete(Expression<Func<ProductModel, bool>> expression);
    }
}
