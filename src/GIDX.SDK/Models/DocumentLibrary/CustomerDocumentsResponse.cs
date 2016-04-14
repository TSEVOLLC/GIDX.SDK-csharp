using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.DocumentLibrary
{
    public class CustomerDocumentsResponse : ResponseBase
    {
        public string MerchantCustomerID { get; set; }
        public int DocumentCount { get; set; }
        public List<Document> Documents { get; set; }
    }
}
