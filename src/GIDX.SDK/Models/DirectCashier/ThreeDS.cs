using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class ThreeDS
    {
        public bool? Enabled { get; set; }
        public string Provider { get; set; }
        public string CAVV { get; set; }
        public string ECI { get; set; }
        public string TransactionID { get; set; }
        public string ACSTransactionID { get; set; }
        public string DSTransactionID { get; set; }
    }
}
