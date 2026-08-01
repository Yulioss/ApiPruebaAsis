using ApiPruebaAsis.Application.DTOs;
using ApiPruebaAsis.Application.DTOs.Product;
using ApiPruebaAsis.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaAsis.Controllers
{
    //[Authorize]
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
        public async Task<ActionResult<ProductDto>> Create(CreateProductDto dto)
        {
            var product = await _productService.CreateAsync(dto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = product.ProductId },
                product);
        }

        [HttpPost("Generate", Name = "GenerateProducts")]
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CreateProductDto dto)
        {
            await _productService.Update(id, dto);
            return Ok(new
            {
                Message = $"Producto actualizado."
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _productService.Delete(id);

            return Ok(new
            {
                Message = $"Producto eliminado."
            });
        }
    }
}
