using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations;
using Nest;
using RepositoryLayer.Models;
using RepositoryLayer;
using BusinessLayer;
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
    }
}
