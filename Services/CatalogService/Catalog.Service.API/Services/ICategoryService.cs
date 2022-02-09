using Catalog.Service.API.Dtos;
using Catalog.Service.API.Model;
using Shared.BaseResponses;
using Shared.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.Service.API.Services
{
    public interface ICategoryService
    {
        Task<Response<List<CategoryDto>>> GetAllAsync();

        Task<Response<CategoryDto>> CreateAsync(CategoryDto category);

        Task<Response<CategoryDto>> GetByIdAsync(string id);
    }
}
