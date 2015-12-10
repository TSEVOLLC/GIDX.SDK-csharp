using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class Document
    {
        public string DocumentID { get; set; }
        public CategoryType CategoryType { get; set; }
        public DocumentStatus DocumentStatus { get; set; }
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public DateTime DateTime { get; set; }
        public List<DocumentNote> DocumentNotes { get; set; }
    }
}
