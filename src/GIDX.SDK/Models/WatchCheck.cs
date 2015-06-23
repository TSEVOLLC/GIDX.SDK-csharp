using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class WatchCheck
    {
        public string SourceCode { get; set; }
        public decimal SourceScore { get; set; }
        public bool MatchResult { get; set; }
        public decimal MatchScore { get; set; }
    }
}
