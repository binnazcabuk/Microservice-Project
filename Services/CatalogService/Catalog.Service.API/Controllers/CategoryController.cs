using Catalog.Service.API.Dtos;
using Catalog.Service.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseResponses;
using System.Threading.Tasks;

namespace Catalog.Service.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService=categoryService;
        }

        [HttpGet]
        public async Task<BaseResponse> getAll()
        {
            var response = await _categoryService.getAllAsync();

            return new BaseResponse<object>(response);
        }

        [HttpPost("create")]
        public async Task<BaseResponse> create(CategoryDto categoryDto)
        {
            var response = await _categoryService.createAsync(categoryDto);

            return new BaseResponse<object>(response);
        }

        [HttpGet("{id}")]
        public async Task<BaseResponse> getById(string id)
        {
            var response = await _categoryService.getbyIdAsync(id);

            return new BaseResponse<object>(response);
        }
    }
}
