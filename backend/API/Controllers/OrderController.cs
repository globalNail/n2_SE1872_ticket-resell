using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.DTOs.Order;
using Service.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var orderResponse = await _orderService.CreateOrder(dto);
                return Ok(orderResponse);
            }
            catch (Exception ex)
            {
                // Bạn có thể thay đổi cách xử lý lỗi tùy thuộc vào yêu cầu cụ thể
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}
