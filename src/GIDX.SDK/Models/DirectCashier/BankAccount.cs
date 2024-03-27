﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class BankAccount : PaymentMethod
    {
        public override string Type => "ACH";

        public string AccountNumber { get; set; }
        public string RoutingNumber { get; set; }
    }
}
