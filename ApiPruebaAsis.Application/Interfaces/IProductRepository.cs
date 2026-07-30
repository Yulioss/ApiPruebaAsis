using ApiPruebaAsis.Application.DTOs.Product;
using ApiPruebaAsis.Application.DTOs;
using ApiPruebaAsis.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Application.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> AddAsync(Product product);
        Task AddRangeAsync(List<Product> products);
        Task<PagedResponse<Product>> GetProductsAsync(ProductQueryDto query);
        Task<Product?> GetByIdAsync(int id);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Product product);
    }
}
