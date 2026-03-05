using Azure;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController(IOrderService orderService) : Controller
    {
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAsync(Application.DTOs.Order.OrderRequestDTO request)
        {
            var response = await orderService.CreateAsync(request);
            if (!response.Successful)
            {
                return StatusCode(response.HttpCode, new { response.UserMessage });
            }

            return Ok(new { response.OrderId });
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById([FromQuery] int orderId)
        {
            var response = await orderService.GetOrderByIdAsync(new Application.DTOs.Order.OrderByIdRequestDTO
            {
                OrderId = orderId
            });

            if (!response.Successful)
            {
                return StatusCode(response.HttpCode, new { response.UserMessage });
            }

            return Ok(response.Order);
        }
    }
}
