using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public interface IMerchantCredentials
    {
        string ApiKey { get; set; }
        string MerchantID { get; set; }
        string ProductTypeID { get; set; }
        string DeviceTypeID { get; set; }
        string ActivityTypeID { get; set; }
    }
}
