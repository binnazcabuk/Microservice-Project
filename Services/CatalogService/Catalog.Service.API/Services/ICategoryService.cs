using Catalog.Service.API.Dtos;
using Catalog.Service.API.Model;
using Shared.BaseResponses;
using System.Threading.Tasks;

namespace Catalog.Service.API.Services
{
    public interface ICategoryService
    {
        Task<BaseResponse> getAllAsync();
        Task<BaseResponse> createAsync(CategoryDto category);
        Task<BaseResponse> getbyIdAsync(string id);
    }
}
