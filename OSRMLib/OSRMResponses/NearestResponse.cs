using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSRMLib.OSRMResponses
{
    class NearestResponse:BaseResponse
    {
        [JsonProperty("waypoints")]
        public Waypoint[] Waypoints { get; set; }
    }
}
