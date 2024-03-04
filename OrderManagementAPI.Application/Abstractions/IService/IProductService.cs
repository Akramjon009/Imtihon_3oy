using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Models;
using System.Linq.Expressions;

namespace OrderManagementAPI.Application.Abstractions.IService
{
    public interface IProductService
    {
        public Task<ProductModel> Create(ProductDTO productDTO, string Password);
        public Task<IEnumerable<ProductDTO>> GetAll();
        public Task<ProductDTO> GetById(long Id);
        public Task<ProductModel> Update(long id, string password, ProductDTO productDTO);
        public Task<ProductModel> UpdateCaunt(long Id, string password, long caunt);
        public Task<ProductModel> UpdateDescription(long Id, string password, string description);
        public Task<ProductModel> UpdateName(long Id, string name, string password);
        public Task<ProductModel> SelProduct(string Name, string description);
        public Task<bool> DeleteProduct(long id, string password);

    }
}
