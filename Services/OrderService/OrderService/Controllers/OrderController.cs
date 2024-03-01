using Microsoft.AspNetCore.Mvc;
using OrderService.Service.Models;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderProcessor _orderProcessor;

        public OrderController(IOrderProcessor orderProcessor)
        {
            _orderProcessor = orderProcessor;
        }

        [HttpPost("add")]
        public async Task<IActionResult> PlaceOrder([FromBody] OrderDto orderDto)
        {
            await _orderProcessor.ProcessOrderAsync(orderDto);
            return Ok();
        }
    }
}
