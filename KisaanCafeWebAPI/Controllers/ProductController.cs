using KisaanCafe.Models;
using KisaanCafe.Services.Product;
using Microsoft.AspNetCore.Mvc;

namespace KisaanCafeWebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _services;

        public ProductController(IProductServices services)
        {
            _services = services;
        }

        [HttpGet("GetAllProducts", Name = "GetAllProducts")]
        public async Task<IActionResult> GetAllProductAsync()
        {
            try
            {
                var products = await _services.GetProductDetailsAsync();

                if (products == null || !products.Any())
                {
                    return NoContent(); // Or any other appropriate status code
                }

                return Ok(products);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, "Internal Server Error");
            }
        }
        [HttpPost("AddProduct", Name = "AddProduct")]
        public async Task<IActionResult> AddProductAsync([FromBody] ProductCommand product)
        {
            try
            {
                var addedProducts = await _services.AddProductAsync(product).ConfigureAwait(false);
                return Ok(addedProducts);
            }
            catch (Exception ex)
            {
                // Log the exception or handle it appropriately
                return StatusCode(500, ex);
            }
        }
    }
}
