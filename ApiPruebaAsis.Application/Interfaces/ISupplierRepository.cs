using ApiPruebaAsis.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Application.Interfaces
{
    public interface ISupplierRepository
    {
        Task<List<Supplier>> GetAllAsync();
        Task<Supplier> AddAsync(Supplier supplier);
        Task<Supplier?> GetByIdAsync(int id);
    }
}
