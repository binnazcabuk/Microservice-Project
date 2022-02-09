using BasketService.API.Services;
using MassTransit;
using Shared.Messages;
using System.Text.Json;
using System.Threading.Tasks;

namespace BasketService.API.Consumers
{
    public class CourseNameChangedEventConsumer : IConsumer<CourseNameChangedEvent>
    {
        private readonly RedisService _redisService;

        public CourseNameChangedEventConsumer(RedisService redisService)
        {
            _redisService = redisService;
        }

        public async Task Consume(ConsumeContext<CourseNameChangedEvent> context)
        {
            
           ///

        }
    }
}
