using Dapper;
using DiscountService.API.Models;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Shared.BaseResponses;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountService.API.Services
{
    public class DiscountServices : IDiscountService
    {
        private readonly IConfiguration _configuration;
        private readonly IDbConnection _dbConnection;

        public DiscountServices(IConfiguration configuration)
        {
            _configuration = configuration;

            _dbConnection = new NpgsqlConnection(_configuration.GetConnectionString("PostgreSql"));
        }

        public async Task<BaseResponse> Delete(int id)
        {
            var status = await _dbConnection.ExecuteAsync("delete from discount where id=@Id", new { Id = id });

            return status > 0 ? new BaseResponse() : BaseErrorCode.ecUknownError.CreateResponse("Discount not found");
        }

        public async Task<BaseResponse> GetAll()
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("Select * from discount");

            return new  BaseResponse<List<Discount>>(discounts.ToList());
        }

        public async Task<BaseResponse> GetByCodeAndUserId(string code, string userId)
        {
            var discounts = await _dbConnection.QueryAsync<Models.Discount>("select * from discount where userid=@UserId and code=@Code", new { UserId = userId, Code = code });

            var hasDiscount = discounts.FirstOrDefault();

            if (hasDiscount == null)
            {
                return BaseErrorCode.ecUknownError.CreateResponse("Discount not found");
            }

            return new BaseResponse<Discount>(hasDiscount);
        }

        public async Task<BaseResponse> GetById(int id)
        {
            var discount = (await _dbConnection.QueryAsync<Models.Discount>("select * from discount where id=@Id", new { Id = id })).SingleOrDefault();

            if (discount == null)
            {
                return BaseErrorCode.ecUknownError.CreateResponse("Discount not found");
            }

            return new BaseResponse<Discount>(discount);
        }

        public async Task<BaseResponse> Save(Discount discount)
        {
            var saveStatus = await _dbConnection.ExecuteAsync("INSERT INTO discount (userid,rate,code) VALUES(@UserId,@Rate,@Code)", discount);

            if (saveStatus > 0)
            {
                return new BaseResponse<string>("Başarılı");
            }

            return BaseErrorCode.ecUknownError.CreateResponse("an error occurred while adding");
        }

        public async Task<BaseResponse> Update(Discount discount)
        {
            var status = await _dbConnection.ExecuteAsync("update discount set userid=@UserId, code=@Code, rate=@Rate where id=@Id", new { Id = discount.id, UserId = discount.userId, Code = discount.code, Rate = discount.rate });

            if (status > 0)
            {
                return new BaseResponse<string>("Güncellendi");
            }

            return BaseErrorCode.ecUknownError.CreateResponse("Discount not found");
        }
    }
}
