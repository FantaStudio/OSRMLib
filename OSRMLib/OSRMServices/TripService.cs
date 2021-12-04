using OSRMLib.Helpers;
using OSRMLib.OSRMResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSRMLib.OSRMServices
{
    public class TripService : BaseService
    {
        /// <summary>
        /// Returned route is a roundtrip (route returns to first location)
        /// </summary>
        public bool RoundTrip { get; set; }

        /// <summary>
        /// Returned route starts at any or first coordinate
        /// </summary>
        /// <value>any is default</value>
        public Source Source { get; set; }

        /// <summary>
        /// Returned route ends at any or last coordinate
        /// </summary>
        /// <value>any is default</value>
        public Destination Destination { get; set; }

        /// <summary>
        /// Returned route instructions for each trip
        /// </summary>
        /// <value>false is default</value>
        public bool Steps { get; set; }

        /// <summary>
        /// Returns additional metadata for each coordinate along the route geometry.
        /// </summary>
        /// <value>false is default</value>
        public Annotations Annotations { get; set; }

        /// <summary>
        /// Add overview geometry either full, simplified according to highest zoom level it could be display on, or not at all.
        /// </summary>
        /// <value>Simplified is default/value>
        public Overview Overview { get; set; }

        public TripService() : base()
        {
            Service = Helpers.Service.Trip;
        }

        protected override Dictionary<string, string> GetAdditionalURLParams()
        {
            var addParams = new Dictionary<string, string>();
            if (!RoundTrip)
            {
                addParams.Add("roundtrip", RoundTrip.ToString());
            }

            if (Source != default)
            {
                addParams.Add("source", EnumHelper.ParseEnumToString(Source));
            }

            if (Destination != default)
            {
                addParams.Add("destination", EnumHelper.ParseEnumToString(Destination));
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
            return addParams.Count > 0 ? addParams : null;
        }

        public async Task<TripResponse> Call() => await Call<TripResponse>();
    }
}
