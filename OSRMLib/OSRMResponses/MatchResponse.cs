using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSRMLib.OSRMResponses
{
    class MatchResponse : BaseResponse
    {
        [JsonProperty("tracepoints")]
        public Waypoint[] Tracepoints { get; set; }

        [JsonProperty("matchings")]
        public Route[] Matchings { get; set; }
    }
}
