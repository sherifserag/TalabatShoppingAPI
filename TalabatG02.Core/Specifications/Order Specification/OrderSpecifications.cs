using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalabatG02.Core.Entities.Order_Aggregation;

namespace TalabatG02.Core.Specifications.Order_Specification
{
    public class OrderSpecifications:BaseSpecification<Order>
    {
        public OrderSpecifications(string email)
            :base(O =>O.BuyerEmail == email)
        {
            Includes.Add(O => O.DeliveryMethod);
            Includes.Add(O => O.Items);

            AddOrderByDesc(O => O.OrderDate);
        }

        public OrderSpecifications(int orderId,string email)
           : base(O => O.BuyerEmail == email && O.Id == orderId)
        {
            Includes.Add(O => O.DeliveryMethod);
            Includes.Add(O => O.Items);

           
        }

    }
}
