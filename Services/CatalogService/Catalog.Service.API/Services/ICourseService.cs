using Catalog.Service.API.Dtos;
using Shared.BaseResponses;
using System.Threading.Tasks;

namespace Catalog.Service.API.Services
{
    public interface ICourseService
    {
        Task<BaseResponse> getAllAsync();
        Task<BaseResponse> getByIdAsync(string id);
        Task<BaseResponse> getAllByUserIdAsync(string id);
        Task<BaseResponse> createAsync(CourseCreatedDto courseDto);
        Task<BaseResponse> updateAsync(CourseUpdatedDto updatedDto);
        Task<BaseResponse> deleteAsync(string id);

    }
}
