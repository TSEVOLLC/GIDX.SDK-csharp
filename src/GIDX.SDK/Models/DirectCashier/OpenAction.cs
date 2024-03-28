using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class OpenAction : TransactionAction
    {
        public override string Type => "Open";

        public string URL { get; set; }
    }
}
