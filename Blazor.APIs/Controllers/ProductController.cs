using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace Blazor.APIs.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IBusiness _business;

        public ProductController(IBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<ActionResult<List<ProductVM>>> GetProducts()
        {
            var products = await _business.GetProducts();
            return Ok(products);
        }

        [HttpPost]
        [Route("AddProduct")]
        public async Task<ActionResult<int>> AddProduct(ProductVM product)
        {
            var newProductId = await _business.AddProduct(product);
            return newProductId;
        }

        [HttpDelete]
        [Route("DeleteProduct/{productId}")]
        public async Task<IActionResult> DeleteProduct(int productId)
        {
            await _business.DeleteProduct(productId);
            return Ok();
        } 

        [HttpPut]
        [Route("UpdateProduct/{productId}")]
        public async Task<IActionResult> UpdateProduct(int productId, ProductVM updatedProduct)
        {
            await _business.UpdateProduct(productId, updatedProduct);
            return Ok();
        }

        [HttpGet]
        [Route("GetProductById/{productId}")]
        public async Task<ActionResult<ProductVM>> GetProductById(int productId)
        {
            var product = await _business.GetProductById(productId);
            return Ok(product);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<ActionResult<ProductVM>> GetById(int Id)
        {
            var product = await _business.GetOrderById(Id);
            return Ok(product);
        }

    }
}
