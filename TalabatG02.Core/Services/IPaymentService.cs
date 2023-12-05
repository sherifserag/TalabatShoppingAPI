using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Entities.Order_Aggregation;

namespace TalabatG02.Core.Services
{
    public interface IPaymentService
    {
        Task<CustomerBasket?> CreateOrUpdatePaymentIntent(string basketId);

        Task<Order> UpdatePaymentIntentToSucceedOrFaild(string IntentId, bool isSucceed);
    }
}
