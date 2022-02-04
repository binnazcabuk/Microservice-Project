using DiscountService.API.Models;
using Shared.BaseResponses;
using System.Threading.Tasks;

namespace DiscountService.API.Services
{
    public interface IDiscountService
    {
        Task<BaseResponse> GetAll();

        Task<BaseResponse> GetById(int id);

        Task<BaseResponse> Save(Discount discount);

        Task<BaseResponse> Update(Discount discount);

        Task<BaseResponse> Delete(int id);

        Task<BaseResponse> GetByCodeAndUserId(string code, string userId);
    }
}
