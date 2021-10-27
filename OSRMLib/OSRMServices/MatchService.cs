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
        public bool Steps { get; set; }
        public string Annotations { get; set; }
        public string Overview { get; set; }
        public IEnumerable<long> Timestamps { get; set; }
        public string Gaps { get; set; }
        public bool Tidy { get; set; }
        public IEnumerable<int> Waypoints { get; set; }

        public MatchService() : base()
        {
            Service = Helpers.Service.Match;
        }

        protected override Dictionary<string, string> GetAdditionalURLParams()
        {
            var addParams = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(Annotations))
            {
                addParams.Add("annotations", Annotations);
            }

            if (!string.IsNullOrEmpty(Overview))
            {
                addParams.Add("overview", Overview);
            }


            if (Timestamps != null && Timestamps.Count() > 0)
            {
                addParams.Add("timestamps", OSRMApi.CreateAnyUrlParam(Timestamps));
            }

            if (!string.IsNullOrEmpty(Gaps))
            {
                addParams.Add("gaps", Gaps);
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
