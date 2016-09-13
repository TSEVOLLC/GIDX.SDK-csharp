using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GIDX.SDK.Models;

namespace GIDX.SDK
{
    public interface IClient
    {
        MerchantCredentials Credentials { get; set; }
    }
}
