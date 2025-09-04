using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class FinixTokenizerSettings : TokenizerSettings
    {
        public override string Type => "Finix";

        public string ApplicationID { get; set; }
    }
}
