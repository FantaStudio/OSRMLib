using Newtonsoft.Json;
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
        public string Alternatives { get; set; }
        public bool Steps { get; set; }
        public string Annotations { get; set; }
        public string Overview { get; set; }
        public string ContinueStraight { get; set; }
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
            if (!string.IsNullOrEmpty(Annotations))
            {
                addParams.Add("annotations", Annotations);
            }
            if (!string.IsNullOrEmpty(Overview))
            {
                addParams.Add("overview", Overview);
            }
            if (!string.IsNullOrEmpty(ContinueStraight))
            {
                addParams.Add("continue_straight", ContinueStraight);
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
