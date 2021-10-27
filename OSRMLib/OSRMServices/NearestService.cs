using Newtonsoft.Json;
using OSRMLib.Helpers;
using OSRMLib.OSRMResponses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OSRMLib.OSRMServices
{
    public class NearestService : BaseService
    {
        public int? Number { get; set; }

        public NearestService() : base()
        {
            Service = Helpers.Service.Nearest;
        }

        protected override Dictionary<string, string> GetAdditionalURLParams()
        {
            if (Number != null)
            {
                return new Dictionary<string, string>() { { "number", Number.ToString() } };
            }
            return base.GetAdditionalURLParams();
        }

        public async Task<NearestResponse> Call() => await Call<NearestResponse>();
    }
}
