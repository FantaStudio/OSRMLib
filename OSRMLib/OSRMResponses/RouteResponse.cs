using Newtonsoft.Json;
using OSRMLib.OSRMResponses;

public class RouteResponse:BaseResponse
{

    [JsonProperty("waypoints")]
    public Waypoint[] Waypoints { get; set; }

    [JsonProperty("routes")]
    public Route[] Routes { get; set; }
}

