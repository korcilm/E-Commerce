using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace API.Core.DbModels.OrderAggregate
{
    public enum OrderStatus
    {
        [EnumMember(Value ="Pending")]
        Pending,
        [EnumMember(Value = "Payment Recieved")]
        PaymentRecieved,
        [EnumMember(Value = "Payment Failed")]
        PaymentFailed
    }
}
