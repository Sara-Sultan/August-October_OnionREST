using System;
using System.Collections.Generic;
using System.Text;

namespace Application.IServices
{
    public interface IServiceManager
    {
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
    }
}
