using OSRMLib.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace OSRMLib.OSRMServices
{
    public class NearestService : BaseService
    {
        public int? Number { get; set; }

        protected override Dictionary<string, string> GetAdditionalURLParams()
        {
            if (Number != null)
            {
                return new Dictionary<string, string>() { { "number", Number.ToString() } };
            }
            return base.GetAdditionalURLParams();
        }
    }
}
