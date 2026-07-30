using ApiPruebaAsis.Application.DTOs;
using ApiPruebaAsis.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaAsis.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        public readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public async Task<IActionResult> GenerateProducts(GenerateProductsDto dto)
        {
            await _productService.GenerateProductsService(dto.Quantity);

            return Ok(new
            {
                Message = $"{dto.Quantity} productos generados correctamente."
            });
        }
    }
}
