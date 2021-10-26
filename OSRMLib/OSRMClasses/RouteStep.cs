using Newtonsoft.Json;
using OSRMLib.Helpers;
using System.Linq;


public class RouteStep
{
    [JsonProperty("distance")]
    public double Distance { get; set; }

    [JsonProperty("duration")]
    public double Duration { get; set; }

    [JsonProperty("geometry")]
    public string GeometryStr { get; set; }

    public Location[] Geometry
    {
        get
        {
            if (string.IsNullOrEmpty(GeometryStr))
            {
                return new Location[0];
            }

            return OSRMPolylineConverter.Decode(GeometryStr, 1E5).ToArray();
        }
    }

    [JsonProperty("maneuver")]
    public StepManeuver Maneuver { get; set; }

    [JsonProperty("mode")]
    public string Mode { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("weight")]
    public double Weight { get; set; }

}

