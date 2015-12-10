using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class DocumentRegistrationRequest : RequestBase
    {
        public string MerchantCustomerID { get; set; }
        public CategoryType CategoryType { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
    }
}
