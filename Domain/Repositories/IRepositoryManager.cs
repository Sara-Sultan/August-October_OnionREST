using Domain.UOW;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IRepositoryManager
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategoryRepository { get; }

        IUnitOfWork UnitOfWork { get; }
    }
}
