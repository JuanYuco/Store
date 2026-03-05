using Microsoft.AspNetCore.Mvc;
using Store.Application.Interfaces;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController(IProductService productService) : Controller
    {
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await productService.GetAllAsync(new Application.DTOs.Product.ProductCollectionRequestDTO());
            if (!response.Successful)
            {
                return StatusCode(response.HttpCode, new { response.UserMessage });
            }

            return Ok(response.Products);
        }
    }
}
