using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSRMLib.OSRMResponses
{
    public abstract class BaseResponse
    {
        [JsonProperty("code")]
        public string Code { get; set; }
    }
}
