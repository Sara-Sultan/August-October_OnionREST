using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync(IPagingInputDto pagingInputDto, CancellationToken cancellationToken = default);
        Task<IEnumerable<Product>> GetByCategoryID(Guid categoryID, CancellationToken cancellationToken = default);

        Task<Product> GetByIdAsync(Guid ProductId, CancellationToken cancellationToken = default);

        void Insert(Product Product);

        void Remove(Product Product);
    }
}
