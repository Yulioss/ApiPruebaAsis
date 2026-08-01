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
        public async Task<ProductDto> CreateAsync(CreateProductDto dto)
        {
            var category = await _categoryRepository.GetByIdAsync(dto.CategoryId);

            if (category == null)
                throw new NotFoundException($"La categoría {dto.CategoryId} no existe.");

            if (dto.SupplierId.HasValue)
            {
                var supplier = await _supplierRepository.GetByIdAsync(dto.SupplierId.Value);

                if (supplier == null)
                    throw new NotFoundException($"El proveedor {dto.SupplierId} no existe.");
            }

            var product = _mapper.Map<Product>(dto);

            product = await _repository.AddAsync(product);

            product = await _repository.GetByIdAsync(product.ProductId);

            return _mapper.Map<ProductDto>(product!);
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

        public async Task Update(int id, CreateProductDto dto)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                throw new NotFoundException($"No existe un producto con el id {id}");

            _mapper.Map(dto, product);

            await _repository.UpdateAsync(product);
        }

        public async Task Delete(int id)
        {
            var product = await _repository.GetByIdAsync(id);

            if (product == null)
                throw new NotFoundException($"No existe un producto con el id {id}");

            await _repository.DeleteAsync(product);
        }
    }
}
