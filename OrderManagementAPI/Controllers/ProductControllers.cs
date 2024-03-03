using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagementAPI.Application.Abstractions.IService;
using OrderManagementAPI.Attrebutes;
using OrderManagementAPI.Domen.Entites.DTOs;
using OrderManagementAPI.Domen.Entites.Enums;
using OrderManagementAPI.Domen.Entites.Models;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ProductControllers : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductControllers(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        [IdentityFilter(Permission.Create)]
        public async Task<ActionResult<ProductModel>> CreateProduct(ProductDTO product)
        {
            var result = await _productService.Create(product);
            return Ok(result);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetAll)]
        public async Task<ActionResult<IEnumerable<ProductModel>>> GetAll()
        {
            var result = await _productService.GetAll();
            return Ok(result);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetById)]
        public async Task<ActionResult<ProductModel>> GetProductById(long id)
        {
            var result = await _productService.GetById(id);
            return Ok(result);
        }
        [HttpPut]
        [IdentityFilter(Permission.Update)]
        public async Task<ActionResult<ProductModel>> UpdateAllUser(long id, ProductDTO product)
        {
            var result = await _productService.Update(id, product);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdateName)]
        public async Task<ActionResult<ProductModel>> UpdateProductName(long id, string productName)
        {
            var result = await _productService.UpdateName(id, productName);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdateDescription)]
        public async Task<ActionResult<ProductModel>> UpdateProducDesctiption(long id, string productDescription)
        {
            var result = await _productService.UpdateDescription(id, productDescription);
            return Ok(result);
        }
        [HttpPatch]
        [IdentityFilter(Permission.UpdateCaunt)]
        public async Task<ActionResult<ProductModel>> UpdateProducCaunt(long id, long caunt)
        {
            var result = await _productService.UpdateCaunt(id, caunt);
            return Ok(result);
        }

    }
}
