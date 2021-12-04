using Newtonsoft.Json;
using OSRMLib.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return EnumHelper.ParseStringArrayToEnum<Direction>(IndicationsString).ToArray();
        }
    }

    [JsonProperty("valid")]
    public bool Valid { get; set; }
}
