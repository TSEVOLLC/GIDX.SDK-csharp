using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK
{
    public interface IGIDXClient : IClient
    {
        ICustomerIdentityClient CustomerIdentity { get; }
        IDocumentLibraryClient DocumentLibrary { get; }
        IWebCashierClient WebCashier { get; }
        IWebRegClient WebReg { get; }
    }
}
