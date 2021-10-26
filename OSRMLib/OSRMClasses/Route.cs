using Newtonsoft.Json;
using OSRMLib.Helpers;
using System.Linq;


public class Route
{
    [JsonProperty("distance")]
    public double Distance { get; set; }

    [JsonProperty("duration")]
    public double Duration { get; set; }

    [JsonProperty("weight")]
    public double Weight { get; set; }

    [JsonProperty("weight_name")]
    public string WeightName { get; set; }

    [JsonProperty("geometry")]
    public string GeometryString { get; set; }

    public Location[] Geometry
    {
        get
        {
            if (string.IsNullOrEmpty(GeometryString))
            {
                return new Location[0];
            }
            return OSRMPolylineConverter.Decode(GeometryString, 1E5).ToArray();
        }
    }

    [JsonProperty("legs")]
    public RouteLeg[] Legs { get; set; }

    // For match service
    [JsonProperty("confidence")]
    public float Confidence { get; set; }
}

