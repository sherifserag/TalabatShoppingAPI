using System.ComponentModel.DataAnnotations;
using TalabatG02.Core.Entities.Identity;

namespace TalabatG02.APIs.Dtos
{
    public class OrderDto
    {
        [Required]
        public string BasketId { get; set; }    

        public int DeliveryMethodId { get; set; }   

        public AddressDto ShipToAddress { get; set; }
    }
}
