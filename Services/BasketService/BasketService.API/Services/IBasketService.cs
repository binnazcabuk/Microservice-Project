using BasketService.API.Dtos;
using Shared.BaseResponses;
using Shared.Dtos;
using System.Threading.Tasks;

namespace BasketService.API.Services
{
    public interface IBasketService
    {
      
            Task<Response<BasketDto>> GetBasket(string userId);

            Task<Response<bool>> SaveOrUpdate(BasketDto basketDto);

            Task<Response<bool>> Delete(string userId);
        
    }
}
