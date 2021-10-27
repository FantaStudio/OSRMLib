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
        public IEnumerable<int> Sources { get; set; }
        public IEnumerable<int> Destinations { get; set; }
        public string Annotations { get; set; }
        public double FallbackSpeed { get; set; }
        public string FallbackCoordinate { get; set; }
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

            if (!string.IsNullOrEmpty(FallbackCoordinate))
            {
                addParams.Add("fallback_coordinate", FallbackCoordinate);
            }

            if (Sources != null && Sources.Count() > 0)
            {
                addParams.Add("sources", OSRMApi.CreateAnyUrlParam(Sources));
            }

            if (Destinations != null && Destinations.Count() > 0)
            {
                addParams.Add("destinations", OSRMApi.CreateAnyUrlParam(Destinations));
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
