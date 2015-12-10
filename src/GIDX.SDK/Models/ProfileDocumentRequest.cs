using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class ProfileDocumentRequest : RequestBase
    {
        public string MerchantCustomerID { get; set; }
        public string DocumentID { get; set; }
    }
}
