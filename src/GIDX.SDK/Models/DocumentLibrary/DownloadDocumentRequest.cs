using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.DocumentLibrary
{
    public class DownloadDocumentRequest : RequestBase
    {
        public string DocumentID { get; set; }
    }
}
