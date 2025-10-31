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

        //Device details for Approvely Rapid
        public decimal? ColorDepth { get; set; }
        public decimal? ScreenHeight { get; set; }
        public decimal? ScreenWidth { get; set; }
        public decimal? TimeZone { get; set; }
        public string UserAgent { get; set; }
        public string DeviceID { get; set; }
    }
}
