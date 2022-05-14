using OSRMLib.Helpers;
using OSRMLib.OSRMResponses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSRMLib.OSRMServices
{
    public class TableService : BaseService
    {
        /// <summary>
        /// Use location with given index as source.
        /// </summary>
        public IEnumerable<int> Sources { get; set; }

        /// <summary>
        /// Use location with given index as destination.
        /// </summary>
        public IEnumerable<int> Destinations { get; set; }

        /// <summary>
        /// Return the requested table or tables in response.
        /// </summary>
        /// <value>duration (default), distance , or duration,distance</value>
        public string Annotations { get; set; }

        /// <summary>
        /// If no route found between a source/destination pair, calculate the as-the-crow-flies distance, then use this speed to estimate duration.
        /// </summary>
        /// <value>double > 0</value>
        public double FallbackSpeed { get; set; }

        /// <summary>
        /// When using a FallbackSpeed , use the user-supplied coordinate ( input ), or the snapped location ( snapped ) for calculating distances.
        /// </summary>
        /// input is default
        public FallbackCoordinate FallbackCoordinate { get; set; }

        /// <summary>
        /// Use in conjunction with annotations=durations. Scales the table duration values by this number.
        /// </summary>
        public double ScaleFactor { get; set; }

        public TableService() : base()
        {
            Service = Helpers.Service.Table;
        }

        protected override Dictionary<string, string> GetAdditionalURLParams()
        {
            var addParams = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(Annotations))
            {
                addParams.Add("annotations", Annotations);
            }

            if (FallbackCoordinate != default)
            {
                addParams.Add("fallback_coordinate", EnumHelper.ParseEnumToString(FallbackCoordinate));
            }

            if (Sources != null && Sources.Count() > 0)
            {
                addParams.Add("sources", OSRMApi.CreateAnyUrlParam(Sources));
            }

            if (Destinations != null && Destinations.Count() > 0)
            {
                addParams.Add("destinations", OSRMApi.CreateAnyUrlParam(Destinations));
            }

            if(FallbackSpeed > 0)
            {
                addParams.Add("fallback_speed", FallbackSpeed.ToString());
            }

            if (ScaleFactor > 0)
            {
                addParams.Add("scale_factor", ScaleFactor.ToString());
            }
            return addParams.Count > 0 ? addParams : null;
        }

        public async Task<TableResponse> Call() => await Call<TableResponse>();
    }
}
