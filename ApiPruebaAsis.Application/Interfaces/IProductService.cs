using ApiPruebaAsis.Application.DTOs.Product;
using ApiPruebaAsis.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Application.Interfaces
{
    public interface IProductService
    {
        Task<ProductDto> CreateAsync(CreateProductDto dto);
        Task GenerateProducts(int quantity);
        Task<PagedResponse<ProductDto>> GetProducts(ProductQueryDto query);
        Task<ProductDto?> GetById(int id);
        Task Update(int id, UpdateProductDto dto);
        Task Delete(int id);
    }
}
