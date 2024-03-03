using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.Application.Abstractions.IService;
using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Models;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductControllers : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductControllers(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<ActionResult<ProductModel>> CreateProduct(ProductDTO product)
        {
            var result = await _productService.Create(product);
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAll()
        {
            var result = await _productService.GetAll();
            return Ok(result);
        }
        [HttpGet]
        public async Task<ActionResult<ProductModel>> GetProductById(long id)
        {
            var result = await _productService.GetById(id);
            return Ok(result);
        }
        [HttpPut]
        public async Task<ActionResult<ProductModel>> UpdateAllUser(long id, ProductDTO product)
        {
            var result = await _productService.Update(id, product);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<ActionResult<ProductModel>> UpdateProductName(long id, string productName)
        {
            var result = await _productService.UpdateName(id, productName);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<ActionResult<ProductModel>> UpdateProducDesctiption(long id, string productDescription)
        {
            var result = await _productService.UpdateDescription(id, productDescription);
            return Ok(result);
        }
        [HttpPatch]
        public async Task<ActionResult<ProductModel>> UpdateProducCaunt(long id, long caunt)
        {
            var result = await _productService.UpdateCaunt(id, caunt);
            return Ok(result);
        }

    }
}
