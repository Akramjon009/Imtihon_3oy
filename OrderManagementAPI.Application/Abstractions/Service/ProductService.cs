using OrderManagementAPI.Application.Abstractions.IRepositories;
using OrderManagementAPI.Application.Abstractions.IService;
using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Models;
using System.Linq.Expressions;

namespace OrderManagementAPI.Application.Abstractions.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productrepository)
        {
            _productRepository = productrepository;
        }

        public async Task<ProductModel> Create(ProductDTO productDTO)
        {
            var user = new ProductModel()
            {
                Name = productDTO.Name,
                Description = productDTO.Description,
                Caunt = productDTO.Caunt
            };
            var result = await _productRepository.Create(user);

            return result;
        }

        public async Task<IEnumerable<ProductDTO>> GetAll()
        {
            var users = await _productRepository.GetAll();

            var result = users.Select(model => new ProductDTO
            {
                Name = model.Name,
                Description = model.Description,
                Caunt = model.Caunt

            });

            return result;
        }

        public async Task<ProductModel> GetById(int Id)
        {
            var result = await _productRepository.GetByAny(x => x.Id == Id);
            return result;
        }

        public async Task<ProductModel> Update(int Id, ProductDTO productDTO)
        {
            var res = await _productRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                var user = new ProductModel()
                {
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    Caunt = productDTO.Caunt
                };
                var result = await _productRepository.Update(user);

                return result;
            }
            return new ProductModel();
        }

        public async Task<ProductModel> UpdateCaunt(int Id, long caunt)
        {
            var res = await _productRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                var user = new ProductModel()
                {
                    Caunt = caunt
                };
                var result = await _productRepository.Update(user);

                return result;
            }
            return new ProductModel();
        }

        public async Task<ProductModel> UpdateDescription(int Id, string description)
        {
            var res = await _productRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                var user = new ProductModel()
                {
                    Description = description
                };
                var result = await _productRepository.Update(user);

                return result;
            }
            return new ProductModel();
        }

        public async Task<ProductModel> UpdateName(int Id, string name)
        {
            var res = await _productRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                var user = new ProductModel()
                {
                    Name = name
                };
                var result = await _productRepository.Update(user);

                return result;
            }
            return new ProductModel();
        }

        public async Task<bool> Delete(Expression<Func<ProductModel, bool>> expression)
        {
            var result = await _productRepository.Delete(expression);

            return result;
        }
    }
}
