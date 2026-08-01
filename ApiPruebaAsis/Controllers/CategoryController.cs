using ApiPruebaAsis.Application.DTOs;
using ApiPruebaAsis.Application.DTOs.Category;
using ApiPruebaAsis.Application.DTOs.Product;
using ApiPruebaAsis.Application.Interfaces;
using ApiPruebaAsis.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaAsis.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;

        public CategoryController(ICategoryService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCategoryDto dto)
        {
            var result = await _service.CreateAsync(dto);

            return CreatedAtAction(
            nameof(Create),
            new { id = result.CategoryId },
            result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetAll()
        {
            var categories = await _service.GetAllAsync();

            return Ok(categories);
        }
    }
}
