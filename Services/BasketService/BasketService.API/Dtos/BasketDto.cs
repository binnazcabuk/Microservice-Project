using System.Collections.Generic;
using System.Linq;

namespace BasketService.API.Dtos
{
    public class BasketDto
    {
        public string UserId { get; set; }

        /// <summary>
        /// indirim kodu
        /// </summary>
        public string DiscountCode { get; set; }

        public int? DiscountRate { get; set; }

        public List<BasketItemDto> basketItems { get; set; }

        public decimal TotalPrice
        {
            get => basketItems.Sum(x => x.Price * x.Quantity);
        }
    }
}
