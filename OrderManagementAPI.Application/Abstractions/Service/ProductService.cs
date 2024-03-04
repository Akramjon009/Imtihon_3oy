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
        private readonly IUserRepository _userRepository;
        public ProductService(IProductRepository productrepository, IUserRepository userRepository)
        {
            _productRepository = productrepository;
            _userRepository = userRepository;
        }

        public async Task<ProductModel> Create(ProductDTO productDTO,string Password)
        {
            var res = await _userRepository.GetByAny(x => x.FullName == productDTO.SellarName && x.Id == productDTO.SallerId && x.Password == Password);
            if (res == null)
            {
                var user = new ProductModel()
                {
                    Name = productDTO.Name,
                    Description = productDTO.Description,
                    Caunt = productDTO.Caunt,
                    SallerId = productDTO.SallerId,
                    SallerName = productDTO.SellarName

                };
                var result = await _productRepository.Create(user);

                return result;
            }
            return null;
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

        public async Task<ProductDTO> GetById(long Id)
        {
            var result = await _productRepository.GetByAny(x => x.Id == Id);
            var user = new ProductDTO()
            {
                Name = result.Name,
                SallerId= result.SallerId,
                SellarName = result.SallerName,
                Description = result.Description,
                Caunt = result.Caunt 

            };
            return user;
        }

        public async Task<ProductModel> Update(long id,string password,ProductDTO productDTO)
        {
            var res = await _productRepository.GetByAny(x => x.Id == id);

            if (res != null)
            {
                var user = await _userRepository.GetByAny(x => x.Id == res.SallerId && x.Password == password);
                if (user != null)
                {
                    res.Name = productDTO.Name;
                    res.Description = productDTO.Description;
                    res.Caunt = productDTO.Caunt;
                    res.SallerName = productDTO.Name;   

                    var result = await _productRepository.Update(res);

                    return result;
                }

            }
            return null;
        }

        public async Task<ProductModel> UpdateCaunt(long Id,string password, long caunt)
        {
            var res = await _productRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                var user = await _userRepository.GetByAny(x => x.Id == res.SallerId && x.Password == password);
                if (user != null)
                {
                    res.Caunt = caunt;

                    var result = await _productRepository.Update(res);

                    return result;
                }
            }
            return null;
        }

        public async Task<ProductModel> UpdateDescription(long Id,string password, string description)
        {
            var res = await _productRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                var user = await _userRepository.GetByAny(y => y.Id == res.SallerId && y.Password == password);
                if (user != null)
                {

                    res.Description = description;

                    var result = await _productRepository.Update(res);

                    return result;
                }
            }
            return new ProductModel();
        }

        public async Task<ProductModel> UpdateName(long Id, string name,string password)
        {
            var res = await _productRepository.GetByAny(x => x.Id == Id);

            if (res != null)
            {
                var result = await _userRepository.GetByAny(x => x.Id == res.SallerId && x.Password == password);
                if (result != null)
                {

                    res.Name = name;

                    var result2 = await _productRepository.Update(res);

                    return result2;
                }
            }
            return new ProductModel();
        }
        public async Task<ProductModel> SelProduct(string Name, string description)
        {
            var res = await _productRepository.GetByAny(x => x.Name == Name && x.Description == description);
            var seller = await _userRepository.GetByAny(x => x.Id == res.SallerId);
            if (seller != null && res != null && res.Caunt > 0)
            {
                    
                res.Caunt--;
                seller.Many = res.price - res.price / 100 *10;
                await _userRepository.Update(seller);
                return await _productRepository.Update(res);
                
            }
            return null;


        }

        public async Task<bool> DeleteProduct(long id,string password)
        {
            var product = await _productRepository.GetByAny(x => x.Id == id);
            if (product != null)
            {

                var result1 = await _userRepository.GetByAny(x => x.Id == product.SallerId && x.Password == password);
                if (result1 != null)
                {
                    var result = await _productRepository.Delete(x => x.Id == id);
                    return result;
                }
            }
            return false;
        }
    }
}
