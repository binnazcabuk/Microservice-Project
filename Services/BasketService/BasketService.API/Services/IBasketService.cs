using BasketService.API.Dtos;
using Shared.BaseResponses;
using System.Threading.Tasks;

namespace BasketService.API.Services
{
    public interface IBasketService
    {
        Task<BaseResponse> GetBasket(string userId);

        Task<BaseResponse> SaveOrUpdate(BasketDto basketDto);

        Task<BaseResponse> Delete(string userId);
    }
}
