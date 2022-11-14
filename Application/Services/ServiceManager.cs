using Application.IServices;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IProductService> _lazyProductService;
        private readonly Lazy<ICategoryService> _lazyCategoryService;

        public ServiceManager(IRepositoryManager repositoryManager)
        {
            _lazyProductService = new Lazy<IProductService>(() => new ProductService(repositoryManager));
            _lazyCategoryService = new Lazy<ICategoryService>(() => new CategoryService(repositoryManager));
        }

        public IProductService ProductService => _lazyProductService.Value;
        public ICategoryService CategoryService => _lazyCategoryService.Value;

    }
}
