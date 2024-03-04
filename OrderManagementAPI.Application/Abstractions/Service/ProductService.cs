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

        public async Task<ProductModel> GetById(long Id)
        {
            var result = await _productRepository.GetByAny(x => x.Id == Id);
            return result;
        }

        public async Task<ProductModel> Update(long Id, ProductDTO productDTO)
        {
            var res = await _productRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {

                res.Name = productDTO.Name;
                res.Description = productDTO.Description;
                res.Caunt = productDTO.Caunt;

                var result = await _productRepository.Update(res);

                return result;
            }
            return new ProductModel();
        }

        public async Task<ProductModel> UpdateCaunt(long Id, long caunt)
        {
            var res = await _productRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {

                res.Caunt = caunt;

                var result = await _productRepository.Update(res);

                return result;
            }
            return new ProductModel();
        }

        public async Task<ProductModel> UpdateDescription(long Id, string description)
        {
            var res = await _productRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {

                res.Description = description;

                var result = await _productRepository.Update(res);

                return result;
            }
            return new ProductModel();
        }

        public async Task<ProductModel> UpdateName(long Id, string name)
        {
            var res = await _productRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {

                res.Name = name;

                var result = await _productRepository.Update(res);

                return result;
            }
            return new ProductModel();
        }

        public async Task<bool> Delete(long id)
        {
            var result = await _productRepository.Delete(x=> x.Id ==id);

            return result;
        }

        public async Task<ProductModel> UpdateCountById(long Id, long count)
        {
            var result = await _productRepository.GetByAny(x => x.Id == Id);
            if (result != null)
            {
                result.Caunt = count;
                return await _productRepository.Update(result);
            }
            return new ProductModel();
        }
        public async Task<ProductModel> SelProduct(string Name, string description)
        {
            var res = await _productRepository.GetByAny(x => x.Name == Name && x.Description == description);

            if (res != null && res.Caunt > 0)
            {
                res.Caunt--;
                return await _productRepository.Update(res);
            }
            return null;


        }
    }
}
