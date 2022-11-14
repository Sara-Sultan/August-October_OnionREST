using Domain.Repositories;
using Domain.UOW;
using Persistence.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
        private readonly Lazy<IProductRepository> _lazyProductRepository;
        private readonly Lazy<ICategoryRepository> _lazyCategoryRepository;
        private readonly Lazy<IUnitOfWork> _lazyUnitOfWork;

        public RepositoryManager(ApplicationDbContext dbContext)
        {
            _lazyProductRepository = new Lazy<IProductRepository>(() => new ProductRepository(dbContext));
            _lazyCategoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(dbContext));
            _lazyUnitOfWork = new Lazy<IUnitOfWork>(() => new UnitOfWork(dbContext));
        }

        public IProductRepository ProductRepository => _lazyProductRepository.Value;
        public ICategoryRepository CategoryRepository => _lazyCategoryRepository.Value;

        public IUnitOfWork UnitOfWork => _lazyUnitOfWork.Value;
    }
}

