using ApiPruebaAsis.Application.DTOs.Supplier;
using ApiPruebaAsis.Application.Interfaces;
using ApiPruebaAsis.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaAsis.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _service;

        public SupplierController(ISupplierService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult<SupplierDto>> Create(CreateSupplierDto dto)
        {
            var result = await _service.CreateAsync(dto);

            return CreatedAtAction(
                nameof(Create),
                new { id = result.SupplierId },
                result);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierDto>>> GetAll()
        {
            var suppliers = await _service.GetAllAsync();

            return Ok(suppliers);
        }
    }
}
