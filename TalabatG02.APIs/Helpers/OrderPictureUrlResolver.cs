using AutoMapper;
using TalabatG02.APIs.Dtos;
using TalabatG02.Core.Entities.Order_Aggregation;

namespace TalabatG02.APIs.Helpers
{
    public class OrderPictureUrlResolver:IValueResolver<OrderItem, OrderItemDto,string>
    {
        private readonly IConfiguration configuration;

        public OrderPictureUrlResolver(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Product.PictureUrl))
                return $"{configuration["ApiBaseUrl"]}{source.Product.PictureUrl}";

            return string.Empty;
        }
    }
}
