using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class GooglePaySettings : PaymentMethodSettings
    {
        public override string Type => PaymentMethodType.GooglePay;

        public string Environment { get; set; }
        public string Gateway { get; set; }
        public string GatewayMerchantID { get; set; }
        public string MerchantID { get; set; }
    }
}
