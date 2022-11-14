using Domain;
using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    internal sealed class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Product>> GetAllAsync(IPagingInputDto pagingInputDto, CancellationToken cancellationToken = default)
        {

            // await _dbContext.Products
            //.Include(x => x.Category)
            // .ToListAsync(cancellationToken);

            var query = _dbContext.Products.Include(x => x.Category).AsQueryable();
            var page = query.Skip((pagingInputDto.PageNumber * pagingInputDto.PageSize) - pagingInputDto.PageSize).Take(pagingInputDto.PageSize);
            return await page.ToListAsync(cancellationToken);
        }

        public async Task<Product> GetByIdAsync(Guid ProductId, CancellationToken cancellationToken = default) =>
            await _dbContext.Products
             .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Id == ProductId, cancellationToken);

        public void Insert(Product Product) => _dbContext.Products.Add(Product);

        public void Remove(Product Product) => _dbContext.Products.Remove(Product);
    }
}