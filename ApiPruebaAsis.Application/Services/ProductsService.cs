using ApiPruebaAsis.Application.Interfaces;
using ApiPruebaAsis.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPruebaAsis.Application.Services
{
    public class ProductsService : IProductService
    {
        private readonly IProductRepository _repository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISupplierRepository _supplierRepository;
        public ProductsService(IProductRepository repository, ICategoryRepository categoryRepository, ISupplierRepository supplierRepository)
        {
            _repository = repository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
        }
        public async Task GenerateProductsService(int quantity)
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
    }
}
