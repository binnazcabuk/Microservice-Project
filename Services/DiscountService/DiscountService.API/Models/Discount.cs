using System;

namespace DiscountService.API.Models
{
    [Dapper.Contrib.Extensions.Table("discount")]
    public class Discount
    {
        public int id { get; set; }
        public string userId { get; set; }
        public int rate { get; set; }
        public string code { get; set; }
        public DateTime createdTime { get; set; }
    }
}
