using ApiPruebaAsis.Application.DTOs;
using ApiPruebaAsis.Application.DTOs.Product;
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
            await _productService.GenerateProducts(dto.Quantity);

            return Ok(new
            {
                Message = $"{dto.Quantity} productos generados correctamente."
            });
        }
        [HttpGet]
        public async Task<ActionResult<PagedResponse<ProductDto>>> GetProducts([FromQuery] ProductQueryDto query)
        {
            return Ok(await _productService.GetProducts(query));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDto>> GetById(int id)
        {
            var product = await _productService.GetById(id);

            return Ok(product);
        }
    }
}
