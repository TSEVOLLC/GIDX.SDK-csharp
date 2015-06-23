using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GIDX.SDK.Models
{
    public class Birth : ElementBase
    {
        public string PlaceOfBirth { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
