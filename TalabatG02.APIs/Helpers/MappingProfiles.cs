using AutoMapper;
using TalabatG02.APIs.Dtos;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Entities.Identity;
using TalabatG02.Core.Entities.Order_Aggregation;

namespace TalabatG02.APIs.Helpers
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<Product, ProductToReturnDto>()
                      .ForMember(PD => PD.ProductBrand, O => O.MapFrom(P => P.ProductBrand.Name))
                      .ForMember(PD => PD.ProductType, O => O.MapFrom(P => P.ProductType.Name))
                      .ForMember(PD => PD.PictureUrl, O => O.MapFrom<ProductPictureUrlResolver>());

            CreateMap<CustomerBasketDto, CustomerBasket>().ReverseMap();
            CreateMap<BasketItemDto, BasketItem>().ReverseMap();
            CreateMap<TalabatG02.Core.Entities.Identity.Address, AddressDto>().ReverseMap();

            CreateMap<AddressDto, TalabatG02.Core.Entities.Order_Aggregation.Address>();

            CreateMap<Order, OrderToReturnDto>()
                    .ForMember(d => d.DeliveryMethod, o => o.MapFrom(m => m.DeliveryMethod.ShortName))
                    .ForMember(d => d.DeliveryMethodCost, o => o.MapFrom(m => m.DeliveryMethod.Cost));

            CreateMap<OrderItem, OrderItemDto>()
                    .ForMember(d => d.ProductId, o => o.MapFrom(m => m.Product.ProductId))
                    .ForMember(d => d.ProductName, o => o.MapFrom(m => m.Product.ProductName))
                    .ForMember(d => d.PictureUrl, o => o.MapFrom(m => m.Product.PictureUrl))
                    .ForMember(d => d.PictureUrl, o => o.MapFrom<OrderPictureUrlResolver>());








        }
    }
}
