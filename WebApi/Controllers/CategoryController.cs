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
    [Route("api/Category")]
    [EnableCors("AllowOrigin")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager, ILogger<CategoryController> logger)
        {
            _logger = logger;
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory([FromQuery] PagingInputDto pagingInputDto, CancellationToken cancellationToken)
        {
            var Category = await _serviceManager.CategoryService.GetAllAsync(pagingInputDto,cancellationToken);

            return Ok(Category);
        }

        [HttpGet("{CategoryId:guid}")]
        public async Task<IActionResult> GetCategoryById(Guid CategoryId, CancellationToken cancellationToken)
        {
            var CategoryDto = await _serviceManager.CategoryService.GetByIdAsync(CategoryId, cancellationToken);

            return Ok(CategoryDto);
        }

        [HttpGet("{categoryID}/Products")]
        public async Task<IActionResult> GetProductsByCategoryID(Guid categoryID, CancellationToken cancellationToken)
        {
            var ProductDto = await _serviceManager.ProductService.GetByIdAsync(categoryID, cancellationToken);

            return Ok(ProductDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryForCreationDTO CategoryForCreationDto)
        {
            var CategoryDto = await _serviceManager.CategoryService.CreateAsync(CategoryForCreationDto);

            return CreatedAtAction(nameof(GetCategoryById), new { CategoryId = CategoryDto.Id }, CategoryDto);
        }

    }
    
}
