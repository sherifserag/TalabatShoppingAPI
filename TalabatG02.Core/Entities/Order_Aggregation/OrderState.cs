using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace TalabatG02.Core.Entities.Order_Aggregation
{
    public enum OrderState
    {
        [EnumMember(Value ="Pending")]
        Pending,

        [EnumMember(Value = "Paymet Received")]
        PaymentReceived,

        [EnumMember(Value = "Payment Failed")]
        PaymentFailed
    }
}
