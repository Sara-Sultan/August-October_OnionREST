using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDTO>> GetAllAsync(PagingInputDto pagingInputDto, CancellationToken cancellationToken = default);

        Task<CategoryDTO> GetByIdAsync(Guid categoryId, CancellationToken cancellationToken = default);

        Task<CategoryDTO> CreateAsync(CategoryForCreationDTO categoryForCreationDto, CancellationToken cancellationToken = default);

       // Task UpdateAsync(Guid categoryId, CategoryForUpdateDto categoryForUpdateDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid categoryId, CancellationToken cancellationToken = default);
    }
}
