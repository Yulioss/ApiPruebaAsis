using Xunit;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AutoMapper;
using ApiPruebaAsis.Application.Services;
using ApiPruebaAsis.Application.Interfaces;
using ApiPruebaAsis.Application.DTOs.Product;
using ApiPruebaAsis.Application.DTOs;
using ApiPruebaAsis.Domain.Entitites;
using ApiPruebaAsis.Application.Exceptions;

namespace ApiPruebaAsis.UnitTests.Services
{
    

    public class ProductsServiceTests
    {
        private readonly Mock<IProductRepository> _productRepo = new();
        private readonly Mock<ICategoryRepository> _categoryRepo = new();
        private readonly Mock<ISupplierRepository> _supplierRepo = new();
        private readonly Mock<IMapper> _mapper = new();

        private ProductsService CreateService() =>
            new(_productRepo.Object, _categoryRepo.Object, _supplierRepo.Object, _mapper.Object);

        [Fact]
        public async Task CreateAsync_ShouldThrow_WhenCategoryNotFound()
        {
            _categoryRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Category)null);

            var service = CreateService();

            await Assert.ThrowsAsync<NotFoundException>(() =>
                service.CreateAsync(new CreateProductDto { CategoryId = 1 }));
        }

        [Fact]
        public async Task CreateAsync_ShouldThrow_WhenSupplierNotFound()
        {
            _categoryRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Category());
            _supplierRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Supplier)null);

            var service = CreateService();

            await Assert.ThrowsAsync<NotFoundException>(() =>
                service.CreateAsync(new CreateProductDto { CategoryId = 1, SupplierId = 2 }));
        }

        [Fact]
        public async Task CreateAsync_ShouldReturnProductDto_WhenSuccess()
        {
            var dto = new CreateProductDto { CategoryId = 1 };
            var product = new Product { ProductId = 1 };
            var productDto = new ProductDto();

            _categoryRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(new Category());
            _mapper.Setup(m => m.Map<Product>(dto)).Returns(product);
            _productRepo.Setup(r => r.AddAsync(product)).ReturnsAsync(product);
            _productRepo.Setup(r => r.GetByIdAsync(product.ProductId)).ReturnsAsync(product);
            _mapper.Setup(m => m.Map<ProductDto>(product)).Returns(productDto);

            var service = CreateService();

            var result = await service.CreateAsync(dto);

            Assert.NotNull(result);
            Assert.Equal(productDto, result);
        }

        [Fact]
        public async Task GenerateProducts_ShouldCallAddRangeAsync()
        {
            _categoryRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Category> { new() { CategoryId = 1 } });
            _supplierRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(new List<Supplier> { new() { SupplierId = 1 } });

            var service = CreateService();

            await service.GenerateProducts(2);

            _productRepo.Verify(r => r.AddRangeAsync(It.IsAny<List<Product>>()), Times.Once);
        }

        [Fact]
        public async Task GetProducts_ShouldReturnPagedResponse()
        {
            var query = new ProductQueryDto();
            var paged = new PagedResponse<Product> { Data = new List<Product>(), Page = 1, PageSize = 10, TotalPages = 1, TotalRecords = 0 };
            _productRepo.Setup(r => r.GetProductsAsync(query)).ReturnsAsync(paged);
            _mapper.Setup(m => m.Map<List<ProductDto>>(paged.Data)).Returns(new List<ProductDto>());

            var service = CreateService();

            var result = await service.GetProducts(query);

            Assert.NotNull(result);
            Assert.Equal(1, result.Page);
        }

        [Fact]
        public async Task GetById_ShouldThrow_WhenNotFound()
        {
            _productRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Product)null);

            var service = CreateService();

            await Assert.ThrowsAsync<NotFoundException>(() => service.GetById(1));
        }

        [Fact]
        public async Task GetById_ShouldReturnProductDto_WhenFound()
        {
            var product = new Product();
            var productDto = new ProductDto();
            _productRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);
            _mapper.Setup(m => m.Map<ProductDto>(product)).Returns(productDto);

            var service = CreateService();

            var result = await service.GetById(1);

            Assert.NotNull(result);
            Assert.Equal(productDto, result);
        }

        [Fact]
        public async Task Update_ShouldThrow_WhenNotFound()
        {
            _productRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Product)null);

            var service = CreateService();

            await Assert.ThrowsAsync<NotFoundException>(() => service.Update(1, new CreateProductDto()));
        }

        [Fact]
        public async Task Update_ShouldCallUpdateAsync_WhenFound()
        {
            var product = new Product();
            _productRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);

            var service = CreateService();

            await service.Update(1, new CreateProductDto());

            _productRepo.Verify(r => r.UpdateAsync(product), Times.Once);
        }

        [Fact]
        public async Task Delete_ShouldThrow_WhenNotFound()
        {
            _productRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((Product)null);

            var service = CreateService();

            await Assert.ThrowsAsync<NotFoundException>(() => service.Delete(1));
        }

        [Fact]
        public async Task Delete_ShouldCallDeleteAsync_WhenFound()
        {
            var product = new Product();
            _productRepo.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(product);

            var service = CreateService();

            await service.Delete(1);

            _productRepo.Verify(r => r.DeleteAsync(product), Times.Once);
        }
    }

}
