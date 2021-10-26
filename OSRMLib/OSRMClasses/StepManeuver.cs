using Newtonsoft.Json;
using OSRMLib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;


public class StepManeuver
{
    [JsonProperty("bearing_after")]
    public int BearingAfter { get; set; }

    [JsonProperty("bearing_before")]
    public int BearingBefore { get; set; }

    [JsonProperty("exit")]
    public int Exit { get; set; }

    [JsonProperty("location")]
    protected double[] LocationArray
    {
        set
        {
            if(value.Length > 1)
                Location = new Location(value[0], value[1]); 
        }
    }

    public Location Location { get; set; }
       
    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("modifier")]
    public string ModifierString { get; set; }

    public Direction Modifier
    {
        get => DirectionHelper.ParseStringToDirection(ModifierString);
    }
}

