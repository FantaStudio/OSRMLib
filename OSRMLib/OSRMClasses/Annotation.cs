using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


public class Annotation
{
    [JsonProperty("distance")]
    public double[] Distance { get; set; }

    [JsonProperty("duration")]
    public double[] Duration { get; set; }

    [JsonProperty("weight")]
    public double[] Weight { get; set; }

    [JsonProperty("speed")]
    public float[] Speed { get; set; }

    [JsonProperty("datasources")]
    public int[] DataSources { get; set; }

    [JsonProperty("nodes")]
    public long[] Nodes { get; set; }
}

