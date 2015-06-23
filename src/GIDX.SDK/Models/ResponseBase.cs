using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public abstract class ResponseBase
    {
        public string ApiKey { get; set; }
        public string MerchantID { get; set; }
        public string MerchantSessionID { get; set; }
        public int ResponseCode { get; set; }
        public string ResponseMessage { get; set; }
        public decimal ApiVersion { get; set; }

        /// <summary>
        /// Determines whether the response from the server was successful.
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                return ResponseCode == 0;
            }
        }
    }
}
