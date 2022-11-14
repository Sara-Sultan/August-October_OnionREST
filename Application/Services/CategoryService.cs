using Application.DTO;
using Application.IServices;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Exceptions;

namespace Application.Services
{
    internal sealed class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CategoryService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync(PagingInputDto pagingInputDto, CancellationToken cancellationToken = default)
        {
            var Categorys = await _repositoryManager.CategoryRepository.GetAllAsync(pagingInputDto,cancellationToken);

            var CategorysDto = Mapping.MapperObject.Mapper.Map<IEnumerable< CategoryDTO >> ( Categorys);

            return CategorysDto;
        }

        public async Task<CategoryDTO> GetByIdAsync(Guid CategoryId, CancellationToken cancellationToken = default)
        {
            var Category = await _repositoryManager.CategoryRepository.GetByIdAsync(CategoryId, cancellationToken);

            if (Category is null)
            {
                throw new NotFoundException("Category", CategoryId);
            }

            var CategoryDTO = Mapping.MapperObject.Mapper.Map<CategoryDTO>( Category);

            return CategoryDTO;
        }

        public async Task<CategoryDTO> CreateAsync(CategoryForCreationDTO CategoryForCreationDto, CancellationToken cancellationToken = default)
        {
            var Category = Mapping.MapperObject.Mapper.Map<Category>(CategoryForCreationDto);

            _repositoryManager.CategoryRepository.Insert(Category);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return Mapping.MapperObject.Mapper.Map<CategoryDTO>(Category);
        }
        public async Task DeleteAsync(Guid CategoryId, CancellationToken cancellationToken = default)
        {
            var Category = await _repositoryManager.CategoryRepository.GetByIdAsync(CategoryId, cancellationToken);

            if (Category is null)
            {
                throw new NotFoundException("Category", CategoryId);
            }

            _repositoryManager.CategoryRepository.Remove(Category);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
