using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace WebCoreApp.Data.Enums
{
    public enum PaymentMethod
    {
        [Description("Thanh toán sau khi nhận hàng")]
        CashOnDelivery,
       
        [Description("PayPal")]
        PayPal,
     
    }
}
