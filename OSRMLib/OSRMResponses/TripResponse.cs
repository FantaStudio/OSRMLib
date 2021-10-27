using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSRMLib.OSRMResponses
{
    public class TripResponse : BaseResponse
    {
        [JsonProperty("waypoints")]
        public Waypoint[] Waypoints { get; set; }

        [JsonProperty("trips")]
        public Route[] Trips { get; set; }
    }
}
