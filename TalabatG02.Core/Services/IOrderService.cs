using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities.Order_Aggregation;

namespace TalabatG02.Core.Services
{
    public interface IOrderService
    {
        Task<Order?> CreateOrderAsync(string bayerEmail,string basketId,Address shippingAddress,int DeliveryMethodId);
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);

        Task<Order> GetOrderByIdForUserAsync(int  orderId,string buyerEmail);

        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
