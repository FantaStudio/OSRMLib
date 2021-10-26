using Newtonsoft.Json;
using System;
using OSRMLib.Helpers;


public class Waypoint
{
    [JsonProperty("hint")]
    public string Hint { get; set; }

    [JsonProperty("distance")]
    public double Distance { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("location")]
    protected double[] LocationArray
    {
        set
        {
            if (value.Length > 1)
                Location = new Location(value[0], value[1]);
        }
    }
    public Location Location { get; set; }

    // For Nearest service
    [JsonProperty("nodes")]
    public long[] Nodes { get; set; }

    // For match service
    [JsonProperty("matchings_index")]
    public int MatchingsIndex { get; set; }

    // and for trip
    [JsonProperty("waypoint_index")]
    public int WaypointIndex { get; set; }

    [JsonProperty("alternatives_count")]
    public int AlternativesCount { get; set; }


    // For trip service
    [JsonProperty("trips_index")]
    public int TripsIndex { get; set; }

}

