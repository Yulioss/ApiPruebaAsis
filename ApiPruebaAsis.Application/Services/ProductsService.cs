using ApiPruebaAsis.Application.DTOs.Product;
using ApiPruebaAsis.Application.DTOs;
using ApiPruebaAsis.Application.Interfaces;
using ApiPruebaAsis.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ApiPruebaAsis.Application.Exceptions;

namespace ApiPruebaAsis.Application.Services
{
    public class ProductsService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public ProductsService(IProductRepository repository, ICategoryRepository categoryRepository, ISupplierRepository supplierRepository, IMapper mapper)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }
        public async Task GenerateProducts(int quantity)
        {
            var random = new Random();

            var categories = await _categoryRepository.GetAllAsync();
            var suppliers = await _supplierRepository.GetAllAsync();

            var products = new List<Product>();

            for (int i = 0; i < quantity; i++)
            {
                products.Add(new Product
                {
                    ProductName = $"Producto {Guid.NewGuid():N}".Substring(0, 15),

                    CategoryId = categories[random.Next(categories.Count)].CategoryId,

                    SupplierId = suppliers[random.Next(suppliers.Count)].SupplierId,

                    QuantityPerUnit = $"{random.Next(1, 20)} unidades",

                    UnitPrice = random.Next(10, 1000),

                    UnitsInStock = (short)random.Next(0, 500),

                    UnitsOnOrder = (short)random.Next(0, 50),

                    ReorderLevel = (short)random.Next(5, 20),

                    Discontinued = false
                });
            }

            await _repository.AddRangeAsync(products);
        }

        public async Task<PagedResponse<ProductDto>> GetProducts(ProductQueryDto query)
        {
            var result = await _repository.GetProductsAsync(query);

            return new PagedResponse<ProductDto>
            {
                Data = _mapper.Map<List<ProductDto>>(result.Data),

                Page = result.Page,

                PageSize = result.PageSize,

                TotalPages = result.TotalPages,

                TotalRecords = result.TotalRecords
            };
        }
        public async Task<ProductDto?> GetById(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                throw new NotFoundException("Producto no encontrado.");

            return _mapper.Map<ProductDto>(product);
        }
    }
}
