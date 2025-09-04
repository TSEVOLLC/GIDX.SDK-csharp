using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GIDX.SDK.Models.DirectCashier
{
    public class ThreeDSChallengeAction : TransactionAction
    {
        public override string Type => "3DSChallenge";

        public string Provider { get; set; }
        public string TransactionID { get; set; }
        public string URL { get; set; }
        public string CReq { get; set; }

        public string EvervaultTeamID { get; set; }
        public string EvervaultAppID { get; set; }
    }
}
