using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace Blazor.APIs.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IBusiness _business;

        public OrderController(IBusiness business)
        {
            _business = business;
        }

        [HttpGet]
        [Route("GetOrders")]
        public async Task<ActionResult<List<OrderVM>>> GetOrders()
        {
            var orders = await _business.GetOrders();
            return Ok(orders);
        }

        [HttpGet]
        [Route("GetOrdersByProductId/{productId}")]
        public async Task<IActionResult> GetOrdersByProductId(int productId)
        {
            var orders = await _business.GetOrdersByProductId(productId);
            return Ok(orders);
        }
    }
}
