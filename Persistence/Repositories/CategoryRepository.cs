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
    internal sealed class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task<IEnumerable<Category>> GetAllAsync(IPagingInputDto pagingInputDto, CancellationToken cancellationToken = default)
        //=>
        //await _dbContext.Categories
        //// .Include(x => x.Products)
        //.ToListAsync(cancellationToken);
        {
            var query = _dbContext.Categories.AsQueryable();
            var page = query.Skip((pagingInputDto.PageNumber * pagingInputDto.PageSize) - pagingInputDto.PageSize).Take(pagingInputDto.PageSize);
            return await page.ToListAsync(cancellationToken);
        }

        public async Task<Category> GetByIdAsync(Guid CategoryId, CancellationToken cancellationToken = default) =>
            await _dbContext.Categories
            //   .Include(x => x.Products)
            .FirstOrDefaultAsync(x => x.Id == CategoryId, cancellationToken);

        public void Insert(Category Category) => _dbContext.Categories.Add(Category);

        public void Remove(Category Category) => _dbContext.Categories.Remove(Category);
    }
}