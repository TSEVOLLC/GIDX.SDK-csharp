using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.CustomerIdentity
{
    public class CustomerMonitorRequest : RequestBase, IContestActivity
    {
        public string MerchantCustomerID { get; set; }
        public List<string> ContestCodes { get; set; }
    }
}
