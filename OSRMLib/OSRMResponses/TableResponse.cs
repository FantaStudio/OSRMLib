using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSRMLib.OSRMResponses
{
    class TableResponse : BaseResponse
    {
        [JsonProperty("durations")]
        public List<List<double>> Durations { get; set; }

        [JsonProperty("distances")]
        public List<List<double>> Distances { get; set; }

        [JsonProperty("sources")]
        public Waypoint[] Sources { get; set; }

        [JsonProperty("destinations")]
        public Waypoint[] Destinations { get; set; }
    }
}
