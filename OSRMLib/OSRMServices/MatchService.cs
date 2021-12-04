using OSRMLib.Helpers;
using OSRMLib.OSRMResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRMLib.OSRMServices
{
    public class MatchService : BaseService
    {
        /// <summary>
        /// Returned route steps for each route
        /// </summary>
        ///<value>true , false (default)</value>
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
        /// Timestamps for the input locations in seconds since UNIX epoch. Timestamps need to be monotonically increasing.
        /// </summary>
        public IEnumerable<long> Timestamps { get; set; }

        /// <summary>
        /// Allows the input track splitting based on huge timestamp gaps between points.
        /// </summary>
        /// <value>split is default</value>
        public Gaps Gaps { get; set; }

        /// <summary>
        /// Allows the input track modification to obtain better matching quality for noisy tracks.
        /// </summary>
        /// <value>true , false (default)</value>
        public bool Tidy { get; set; }

        /// <summary>
        /// Treats input coordinates indicated by given indices as waypoints in returned Match object. Default is to treat all input coordinates as waypoints.
        /// </summary>
        public IEnumerable<int> Waypoints { get; set; }

        public MatchService() : base()
        {
            Service = Helpers.Service.Match;
        }

        protected override Dictionary<string, string> GetAdditionalURLParams()
        {
            var addParams = new Dictionary<string, string>();
            if (Annotations != default)
            {
                addParams.Add("annotations", EnumHelper.ParseEnumToString(Annotations));
            }

            if (Overview != default)
            {
                addParams.Add("overview", EnumHelper.ParseEnumToString(Overview));
            }


            if (Timestamps != null && Timestamps.Count() > 0)
            {
                addParams.Add("timestamps", OSRMApi.CreateAnyUrlParam(Timestamps));
            }

            if (Gaps != default)
            {
                addParams.Add("gaps", EnumHelper.ParseEnumToString(Gaps));
            }

            if (Tidy)
            {
                addParams.Add("tidy", Tidy.ToString());
            }

            if (Waypoints != null && Waypoints.Count() > 0)
            {
                addParams.Add("waypoints", OSRMApi.CreateAnyUrlParam(Waypoints));
            }
            return addParams.Count > 0 ? addParams : null;
        }

        public async Task<MatchResponse> Call() => await Call<MatchResponse>();
    }
}
