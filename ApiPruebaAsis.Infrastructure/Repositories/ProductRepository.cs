using ApiPruebaAsis.Application.Interfaces;
using ApiPruebaAsis.Domain.Entitites;
using ApiPruebaAsis.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
