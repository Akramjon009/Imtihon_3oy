using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Models;
using System.Linq.Expressions;

namespace OrderManagementAPI.Application.Abstractions.IService
{
    public interface IProductService
    {
        public Task<ProductModel> Create(ProductDTO productDTO);
        public Task<ProductModel> GetById(int Id);
        public Task<IEnumerable<ProductDTO>> GetAll();
        public Task<ProductModel> Update(int Id, ProductDTO productDTO);
        public Task<ProductModel> UpdateName(int Id, string Name);
        public Task<ProductModel> UpdateDescription(int Id, string description);
        public Task<ProductModel> UpdateCaunt(int Id, long caunt);
        public Task<bool> Delete(Expression<Func<ProductModel, bool>> expression);
    }
}
