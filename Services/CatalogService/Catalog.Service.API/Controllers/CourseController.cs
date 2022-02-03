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
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService=courseService;
        }
        [HttpGet]
        public async Task<BaseResponse> getAll()
        {
            var response = await _courseService.getAllAsync();

            return new BaseResponse<object>(response);
        }

        ///course/5
        [HttpGet("{id}")]
        public async Task<BaseResponse>getById(string id)
        {
            var response = await _courseService.getByIdAsync(id);

            return new BaseResponse<object>(response);
        }

        ///api/course/getAllUserId/4
        [HttpGet("getAllUserId/{userId}")]
        public async Task<BaseResponse> getAllByUserId(string userId)
        {
            var response = await _courseService.getAllByUserIdAsync(userId);

            return new BaseResponse<object>(response);
        }

        [HttpPost("create")]
        public async Task<BaseResponse> create(CourseCreatedDto createdDto)
        {
            var response = await _courseService.createAsync(createdDto);

            return new BaseResponse<object>(response);
        }

        [HttpPost("update")]
        public async Task<BaseResponse> update(CourseUpdatedDto updatedDto)
        {
            var response = await _courseService.updateAsync(updatedDto);

            return new BaseResponse<object>(response);
        }

        [HttpPost("delete/{id}")]
        public async Task<BaseResponse> delete(string id)
        {
            var response = await _courseService.deleteAsync(id);

            return new BaseResponse<object>(response);
        }
    }
}
