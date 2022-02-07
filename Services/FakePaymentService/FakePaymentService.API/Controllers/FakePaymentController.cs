using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.BaseResponses;
using System.Threading.Tasks;

namespace FakePaymentService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FakePaymentController : ControllerBase
    {

        [HttpPost]
        public BaseResponse ReceivePayment()
        {
            return new BaseResponse();
        }

            //private readonly ISendEndpointProvider _sendEndpointProvider;

            //public FakePaymentController(ISendEndpointProvider sendEndpointProvider)
            //{
            //    _sendEndpointProvider = sendEndpointProvider;
            //}

            //[HttpPost]
            //public async Task<IActionResult> ReceivePayment(PaymentDto paymentDto)
            //{
            //    //paymentDto ile ödeme işlemi gerçekleştir.
            //    var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri("queue:create-order-service"));

            //    var createOrderMessageCommand = new CreateOrderMessageCommand();

            //    createOrderMessageCommand.BuyerId = paymentDto.Order.BuyerId;
            //    createOrderMessageCommand.Province = paymentDto.Order.Address.Province;
            //    createOrderMessageCommand.District = paymentDto.Order.Address.District;
            //    createOrderMessageCommand.Street = paymentDto.Order.Address.Street;
            //    createOrderMessageCommand.Line = paymentDto.Order.Address.Line;
            //    createOrderMessageCommand.ZipCode = paymentDto.Order.Address.ZipCode;

            //    paymentDto.Order.OrderItems.ForEach(x =>
            //    {
            //        createOrderMessageCommand.OrderItems.Add(new OrderItem
            //        {
            //            PictureUrl = x.PictureUrl,
            //            Price = x.Price,
            //            ProductId = x.ProductId,
            //            ProductName = x.ProductName
            //        });
            //    });

            //    await sendEndpoint.Send<CreateOrderMessageCommand>(createOrderMessageCommand);

            //    return Ok(Shared.Dtos.Response<NoContent>.Success(200));
            //}
        }
}
