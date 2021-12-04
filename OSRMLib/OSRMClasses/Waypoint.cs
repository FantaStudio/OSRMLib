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

    /// <summary>
    /// Index to the Route object in matchings the sub-trace was matched to.
    /// Working for Match service
    /// </summary>
    // For match service
    [JsonProperty("matchings_index")]
    public int MatchingsIndex { get; set; }

    /// <summary>
    /// Index of the waypoint inside the matched route in Match Service.
    /// Index of the point in the trip in Trip service.
    /// Working for Match and Trip service
    /// </summary>
    // and for trip
    [JsonProperty("waypoint_index")]
    public int WaypointIndex { get; set; }

    /// <summary>
    /// Number of probable alternative matchings for this trace point. A value of zero indicate that this point was matched unambiguously. Split the trace at these points for incremental map matching.
    /// </summary>
    [JsonProperty("alternatives_count")]
    public int AlternativesCount { get; set; }

    /// <summary>
    /// Index to trips of the sub-trip the point was matched to.
    /// Working for  Trip service
    /// </summary>
    // For trip service
    [JsonProperty("trips_index")]
    public int TripsIndex { get; set; }

}

