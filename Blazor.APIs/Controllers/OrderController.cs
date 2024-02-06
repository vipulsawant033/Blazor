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

        [HttpPost("addorder")]
        public async Task<IActionResult> AddOrder([FromQuery] int productId, [FromBody] OrderVM order)
        {
            var orderId = await _business.AddOrder(productId, order);
            return Ok(orderId);
        }
        [HttpDelete]
        [Route("DeleteOrder/{orderId}")]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            await _business.DeleteOrder(orderId);
            return Ok();
        }
    }
}
