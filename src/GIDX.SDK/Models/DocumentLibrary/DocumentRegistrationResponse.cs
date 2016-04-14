using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.DocumentLibrary
{
    public class DocumentRegistrationResponse : ResponseBase
    {
        public string MerchantCustomerID { get; set; }
        public Document Document { get; set; }
    }
}
