using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities.Order_Aggregation;

namespace TalabatG02.Core.Specifications.Order_Specification
{
    public class OrderWithPaymentSpecifications:BaseSpecification<Order>
    {
        public OrderWithPaymentSpecifications(string IntentId)
            :base(o => o.PaymentIntentId == IntentId)
        {
            
        }
    }
}
