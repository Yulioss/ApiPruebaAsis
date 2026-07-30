using ApiPruebaAsis.Application.DTOs.Product;
using ApiPruebaAsis.Application.DTOs;
using ApiPruebaAsis.Application.Interfaces;
using ApiPruebaAsis.Domain.Entitites;
using ApiPruebaAsis.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace ApiPruebaAsis.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task AddRangeAsync(List<Product> products)
        {
            const int batchSize = 1000;

            for (int i = 0; i < products.Count; i += batchSize)
            {
                var batch = products.Skip(i).Take(batchSize);

                await _context.Products.AddRangeAsync(batch);

                await _context.SaveChangesAsync();

                _context.ChangeTracker.Clear();
            }
        }
        public async Task<PagedResponse<Product>> GetProductsAsync(ProductQueryDto query)
        {
            var products = _context.Products
                .Include(p => p.Category)
                .Include(p => p.Supplier)
                .AsNoTracking()
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.Search))
            {
                products = products.Where(x =>
                    x.ProductName.Contains(query.Search));
            }

            if (query.CategoryId.HasValue)
            {
                products = products.Where(x =>
                    x.CategoryId == query.CategoryId);
            }

            if (query.SupplierId.HasValue)
            {
                products = products.Where(x =>
                    x.SupplierId == query.SupplierId);
            }

            if (query.Discontinued.HasValue)
            {
                products = products.Where(x =>
                    x.Discontinued == query.Discontinued);
            }

            var total = await products.CountAsync();

            var result = await products
                .Skip((query.Page - 1) * query.PageSize)
                .Take(query.PageSize)
                .ToListAsync();

            return new PagedResponse<Product>
            {
                Data = result,
                Page = query.Page,
                PageSize = query.PageSize,
                TotalRecords = total,
                TotalPages = (int)Math.Ceiling((double)total / query.PageSize)
            };
        }

        public async Task<Product?> GetByIdAsync(int id)
        {
            return await _context.Products
                .Include(x => x.Category)
                .Include(x => x.Supplier)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.ProductId == id);
        }
    }
}
