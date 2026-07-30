using ApiPruebaAsis.Application.DTOs;
using ApiPruebaAsis.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiPruebaAsis.Controllers
{
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
    }
}
