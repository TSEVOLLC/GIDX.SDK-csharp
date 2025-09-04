using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class EvervaultTokenizerSettings : TokenizerSettings
    {
        public override string Type => "Evervault";

        public string TeamID { get; set; }
        public string AppID { get; set; }
        public string MerchantID { get; set; }
    }
}
