using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTO;
using Application.IServices;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/Products")]
    [EnableCors("AllowOrigin")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IServiceManager _serviceManager;

        public ProductsController(IServiceManager serviceManager, ILogger<ProductsController> logger)
        {
            _logger = logger;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] PagingInputDto pagingInputDto, CancellationToken cancellationToken)
        {
            var Products = await _serviceManager.ProductService.GetAllAsync(pagingInputDto,cancellationToken);

            return Ok(Products);
        }

        [HttpGet("{productId:guid}")]
        public async Task<IActionResult> GetProductById(Guid productId, CancellationToken cancellationToken)
        {
            var ProductDto = await _serviceManager.ProductService.GetByIdAsync(productId, cancellationToken);

            return Ok(ProductDto);
        }
      
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductForCreationDto ProductForCreationDto)
        {
            var ProductDto = await _serviceManager.ProductService.CreateAsync(ProductForCreationDto);

            // return CreatedAtAction(nameof(GetProductById), new { productId = ProductDto.Id }, ProductDto);
            return Ok(new ResponseDTO()
            {
                success = true,
                results = ProductDto,
                messages = ""
            });
        }

        [HttpPut("{productId:guid}")]
        public async Task<IActionResult> UpdateProduct(Guid productId, [FromBody] ProductForUpdateDto ProductForUpdateDto, CancellationToken cancellationToken)
        {
            await _serviceManager.ProductService.UpdateAsync(productId, ProductForUpdateDto, cancellationToken);

            return Ok(new ResponseDTO()
            {
                success = true,
                results = ProductForUpdateDto,
                messages = ""
            });
        }

        [HttpDelete("{productId:guid}")]
        public async Task<IActionResult> DeleteProduct(Guid productId, CancellationToken cancellationToken)
        {
            await _serviceManager.ProductService.DeleteAsync(productId, cancellationToken);

            return NoContent();
        }
    }
    
}
