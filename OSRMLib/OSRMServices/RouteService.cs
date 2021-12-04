using Newtonsoft.Json;
using OSRMLib.Helpers;
using OSRMLib.OSRMResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRMLib.OSRMServices
{
    public class RouteService : BaseService
    {
        /// <summary>
        /// 	Search for alternative routes. Passing a number alternatives=n searches for up to n alternative routes. *
        /// </summary>
        /// <value>true , false (default), or Number</value>
        public string Alternatives { get; set; }

        /// <summary>
        /// Returned route steps for each route leg
        /// </summary>
        /// /// <value>true , false (default)</value>
        public bool Steps { get; set; }

        /// <summary>
        /// Returns additional metadata for each coordinate along the route geometry.
        /// </summary>
        /// <value>False is default</value>
        public Annotations Annotations { get; set; }

        /// <summary>
        /// Add overview geometry either full, simplified according to highest zoom level it could be display on, or not at all.
        /// </summary>
        /// <value>Simplified is default</value>
        public Overview Overview { get; set; }

        /// <summary>
        /// Forces the route to keep going straight at waypoints constraining uturns there even if it would be faster. Default value depends on the profile.
        /// </summary>
        public ContinueStraight ContinueStraight { get; set; }

        /// <summary>
        /// Treats input coordinates indicated by given indices as waypoints in returned Match object. Default is to treat all input coordinates as waypoints.
        /// </summary>
        public IEnumerable<int> Waypoints { get; set; }

        public RouteService() : base()
        {
            Service = Helpers.Service.Route;
        }

        protected override Dictionary<string, string> GetAdditionalURLParams()
        {
            var addParams = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(Alternatives))
            {
                addParams.Add("alternatives", Alternatives);
            }
            if (Steps)
            {
                addParams.Add("steps", Steps.ToString());
            }
            if (Annotations != default)
            {
                addParams.Add("annotations", EnumHelper.ParseEnumToString(Annotations));
            }
            if (Overview != default)
            {
                addParams.Add("overview", EnumHelper.ParseEnumToString(Overview));
            }
            if (ContinueStraight != default)
            {
                addParams.Add("continue_straight", EnumHelper.ParseEnumToString(ContinueStraight));
            }
            if (Waypoints != null && Waypoints.Count() > 0)
            {
                addParams.Add("waypoints", OSRMApi.CreateAnyUrlParam(Waypoints));
            }
            return addParams.Count > 0 ? addParams : null;
        }

        public async Task<RouteResponse> Call() => await Call<RouteResponse>();
    }
}
