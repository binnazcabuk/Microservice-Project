using BasketService.API.Dtos;
using Shared.BaseResponses;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace BasketService.API.Services
{
    public class BasketServices : IBasketService
    {
        private readonly RedisService _redisService;

        public BasketServices(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task<BaseResponse> Delete(string userId)
        {
            var status = await _redisService.GetDb().KeyDeleteAsync(userId);
            return status ? new BaseResponse<bool>(status) : BaseErrorCode.ecUknownError.CreateResponse("Basket not found");
        }

        public async Task<BaseResponse> GetBasket(string userId)
        {
            var existBasket = await _redisService.GetDb().StringGetAsync(userId);

            if (String.IsNullOrEmpty(existBasket))
            {
             return BaseErrorCode.ecUknownError.CreateResponse("Basket not found");
             
            }

            ///gelen veri bir "redis value" bu veriyi deserialize etmek gerekiyor.            
            return new BaseResponse<BasketDto>(JsonSerializer.Deserialize<BasketDto>(existBasket));
        }

        public async Task<BaseResponse> SaveOrUpdate(BasketDto basketDto)
        {
            var status = await _redisService.GetDb().StringSetAsync(basketDto.UserId, JsonSerializer.Serialize(basketDto));

            return status ? new BaseResponse<bool>(status) : BaseErrorCode.ecUknownError.CreateResponse("Basket could not update or save");
        }
    }
}
