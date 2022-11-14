using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetAllAsync(IPagingInputDto pagingInputDto, CancellationToken cancellationToken = default);

        Task<Category> GetByIdAsync(Guid CategoryId, CancellationToken cancellationToken = default);

        void Insert(Category Category);

        void Remove(Category Category);
    }
}
