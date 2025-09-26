using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DocumentInsight
{
    public class File
    {
        public string FileID { get; set; }
        public FileCategory CategoryType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public FileSide Side { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string ContentType { get; set; }
    }
}
