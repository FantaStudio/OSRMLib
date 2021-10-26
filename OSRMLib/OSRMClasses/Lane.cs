using Newtonsoft.Json;
using OSRMLib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

class Lane
{
    [JsonProperty("indications")]
    public string[] IndicationsString { get; set; }

    public Direction[] Indications
    {
        get
        {
            if(IndicationsString.Length < 1)
            {
                return new Direction[0];
            }
            return (Direction[])DirectionHelper.ParseStringArrayToDirection(IndicationsString);
        }
    }

    [JsonProperty("valid")]
    public bool Valid { get; set; }
}
