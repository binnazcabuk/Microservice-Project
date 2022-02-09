using Catalog.Service.API.Dtos;
using Shared.BaseResponses;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Service.API.Services
{
    public interface ICourseService
    {
       
            Task<Response<List<CourseDto>>> GetAllAsync();

            Task<Response<CourseDto>> GetByIdAsync(string id);

            Task<Response<List<CourseDto>>> GetAllByUserIdAsync(string userId);

            Task<Response<CourseDto>> CreateAsync(CourseCreatedDto courseCreateDto);

            Task<Response<NoContent>> UpdateAsync(CourseUpdatedDto courseUpdateDto);

            Task<Response<NoContent>> DeleteAsync(string id);
        }

    }

