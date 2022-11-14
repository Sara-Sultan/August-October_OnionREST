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
    internal sealed class ProductService : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ProductService(IRepositoryManager repositoryManager) => _repositoryManager = repositoryManager;

        public async Task<IEnumerable<ProductDTO>> GetAllAsync(PagingInputDto pagingInputDto,CancellationToken cancellationToken = default)
        {
            var Products = await _repositoryManager.ProductRepository.GetAllAsync(pagingInputDto,cancellationToken);

            var ProductsDto = Mapping.MapperObject.Mapper.Map<IEnumerable< ProductDTO >> ( Products);

            return ProductsDto;
        }
        public async Task<IEnumerable<ProductDTO>> GetByCategoryID(Guid categoryID, CancellationToken cancellationToken = default)
        {
            var Products = await _repositoryManager.ProductRepository.GetByCategoryID(categoryID, cancellationToken);

            var ProductsDto = Mapping.MapperObject.Mapper.Map<IEnumerable<ProductDTO>>(Products);

            return ProductsDto;
        }
        public async Task<ProductDTO> GetByIdAsync(Guid ProductId, CancellationToken cancellationToken = default)
        {
            var Product = await _repositoryManager.ProductRepository.GetByIdAsync(ProductId, cancellationToken);

            if (Product is null)
            {
                throw new NotFoundException("Product", ProductId);
            }

            var ProductDTO = Mapping.MapperObject.Mapper.Map<ProductDTO>( Product);

            return ProductDTO;
        }

        public async Task<ProductDTO> CreateAsync(ProductForCreationDto ProductForCreationDto, CancellationToken cancellationToken = default)
        {
            var Product = Mapping.MapperObject.Mapper.Map<Product>(ProductForCreationDto);

            _repositoryManager.ProductRepository.Insert(Product);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);

            return Mapping.MapperObject.Mapper.Map<ProductDTO>(Product);
        }

        public async Task UpdateAsync(Guid ProductId, ProductForUpdateDto ProductForUpdateDto, CancellationToken cancellationToken = default)
        {
            var Product = await _repositoryManager.ProductRepository.GetByIdAsync(ProductId, cancellationToken);

            if (Product is null)
            {
                throw new NotFoundException("Product", ProductId);
            }

            Product.Name = ProductForUpdateDto.Name;
            Product.Price = ProductForUpdateDto.Price;
            Product.Quantity = ProductForUpdateDto.Quantity;
            Product.ImgURL = ProductForUpdateDto.ImgURL;
            Product.CategoryId = ProductForUpdateDto.CategoryId;

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }

        public async Task DeleteAsync(Guid ProductId, CancellationToken cancellationToken = default)
        {
            var Product = await _repositoryManager.ProductRepository.GetByIdAsync(ProductId, cancellationToken);

            if (Product is null)
            {
                throw new NotFoundException("Product", ProductId);
            }

            _repositoryManager.ProductRepository.Remove(Product);

            await _repositoryManager.UnitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
