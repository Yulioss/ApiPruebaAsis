using ApiPruebaAsis.Application.DTOs.Supplier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Application.Interfaces
{
    public interface ISupplierService
    {
        Task<SupplierDto> CreateAsync(CreateSupplierDto dto);
        Task<IEnumerable<SupplierDto>> GetAllAsync();
    }
}
