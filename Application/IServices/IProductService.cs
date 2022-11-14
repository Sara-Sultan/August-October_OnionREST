using Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetAllAsync(PagingInputDto pagingInputDto, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProductDTO>> GetByCategoryID(Guid categoryID, CancellationToken cancellationToken = default);

        Task<ProductDTO> GetByIdAsync(Guid productId, CancellationToken cancellationToken = default);

        Task<ProductDTO> CreateAsync(ProductForCreationDto productForCreationDto, CancellationToken cancellationToken = default);

        Task UpdateAsync(Guid productId, ProductForUpdateDto productForUpdateDto, CancellationToken cancellationToken = default);

        Task DeleteAsync(Guid productId, CancellationToken cancellationToken = default);
    }
}
