using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhotoStockService.API.Dtos;
using Shared.BaseResponses;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace PhotoStockService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ControllerBase
    {
        [HttpPost("")]
        public async Task<BaseResponse> photoSave(IFormFile photo, CancellationToken cancellationToken)
        {
            ///CancellationToken  foroğraf eklerken bir hata olduğunda tetiklenir ve asekron işlemi durdurur.

            PhotoDto photoDto = new();

            if (photo!=null&& photo.Length>0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures/", photo.FileName);

                using var stream = new FileStream(path, FileMode.Create);
                await photo.CopyToAsync(stream, cancellationToken);

                var pic = "pictures/"+photo.FileName;

                photoDto.Url=pic;
                return new BaseResponse<PhotoDto>(photoDto);
            }

            return BaseErrorCode.ecUknownError.CreateResponse("Photo not found");

        }

       
         [HttpPost("delete")]
        public BaseResponse photoDelete(string photoUrl)
        {
            try
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pictures/", photoUrl);
                System.IO.File.Delete(path);

                return new BaseResponse();
            }
            catch (Exception)
            {
                return BaseErrorCode.ecUknownError.CreateResponse("photo not found");
            }

        }
    }
}
