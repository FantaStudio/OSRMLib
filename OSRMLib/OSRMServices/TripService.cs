using OSRMLib.OSRMResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSRMLib.OSRMServices
{
    public class TripService : BaseService
    {
        public bool RoundTrip { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public bool Steps { get; set; }
        public string Annotations { get; set; }
        public string Overview { get; set; }

        public TripService() : base()
        {
            Service = Helpers.Service.Trip;
        }

        protected override Dictionary<string, string> GetAdditionalURLParams()
        {
            var addParams = new Dictionary<string, string>();
            if (RoundTrip)
            {
                addParams.Add("roundtrip", RoundTrip.ToString());
            }

            if (!string.IsNullOrEmpty(Source))
            {
                addParams.Add("source", Source);
            }

            if (!string.IsNullOrEmpty(Destination))
            {
                addParams.Add("destination", Destination);
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
            return addParams.Count > 0 ? addParams : null;
        }

        public async Task<TripResponse> Call() => await Call<TripResponse>();
    }
}
