using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models.DocumentLibrary
{
    public class DownloadDocumentResponse : ResponseBase
    {
        public string DocumentID { get; set; }
        public Stream FileStream { get; set; }
        public string FileName { get; set; }
    }
}
