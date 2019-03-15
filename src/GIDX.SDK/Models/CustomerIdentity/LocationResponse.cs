using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.CustomerIdentity
{
    public class LocationResponse : ResponseBase
    {
        public string MerchantCustomerID { get; set; }

        public LocationDetail LocationDetail { get; set; }
    }
}
