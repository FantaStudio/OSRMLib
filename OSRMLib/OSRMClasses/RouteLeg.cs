using Newtonsoft.Json;


public class RouteLeg
{
    [JsonProperty("distance")]
    public double Distance { get; set; }

    [JsonProperty("duration")]
    public double Duration { get; set; }

    [JsonProperty("weight")]
    public double Weight { get; set; }

    [JsonProperty("summary")]
    public string Summary { get; set; }

    [JsonProperty("steps")]
    public RouteStep[] Steps { get; set; }

    [JsonProperty("annotation")]
    public Annotation Annotation { get; set; }
}

