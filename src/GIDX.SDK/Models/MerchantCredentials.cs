using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class MerchantCredentials : IMerchantCredentials
    {
        public string ApiKey { get; set; }
        public string MerchantID { get; set; }
        public string ProductTypeID { get; set; }
        public string DeviceTypeID { get; set; }
        public string ActivityTypeID { get; set; }
    }
}
