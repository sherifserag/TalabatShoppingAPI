using System.ComponentModel.DataAnnotations;
using TalabatG02.Core.Entities;

namespace TalabatG02.APIs.Dtos
{
    public class CustomerBasketDto
    {
        [Required]
        public string Id { get; set; }  

        public List<BasketItemDto> Items { get; set; }

        public string? PaymentIntentId { get; set; }

        public string? ClientSecret { get; set; }

        public int? DeliveryMethodId { get; set; }

        public decimal ShippingCost { get; set; }
    }
}
