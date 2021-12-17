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
    public abstract class BaseService
    {
        protected Service? Service { get; set; }
        public string Version { get; set; }
        public string Profile { get; set; }
        public IEnumerable<Location> Coordinates { get; set; }
        public IEnumerable<double> Radiuses { get; set; }
        public bool GenerateHints { get; set; }
        public IEnumerable<string> Hints { get; set; }
        public IEnumerable<string> Exclude { get; set; }
        public bool SkipWaypoints { get; set; }
        public Snapping Snapping { get; set; }

        public BaseService()
        {
            Service = null;
            Version = "v1";
            Profile = "driving";
        }

        protected string GetServiceURL()
        {
            if(Service == null)
                throw new OSRMException("Service is not defined");

            if (string.IsNullOrEmpty(Version))
                throw new OSRMException("Wrong service version") { Service = (Service)Service };

            if (string.IsNullOrEmpty(Profile))
                throw new OSRMException("Wrong service profile") { Service = (Service)Service };

            if (Coordinates == null || Coordinates.Count() < 1)
                throw new OSRMException("Wrong service coordinates") { Service = (Service)Service };

            var serviceString = EnumHelper.ParseEnumToString((Service)Service);

            var basedUrl = $"{serviceString}/{Version}/{Profile}/{OSRMApi.CreateCoordinatesUrlParam(Coordinates)}";
            Dictionary<string, string> parametrs = new Dictionary<string, string>();

            // Base optional params
            if(Radiuses != null && Radiuses.Count() > 0)
            {
                parametrs.Add("radiuses", OSRMApi.CreateDoubleUrlParam(Radiuses));
            }
            if (GenerateHints)
            {
                parametrs.Add("generate_hints", GenerateHints.ToString());
            }
            if (Hints != null && Hints.Count() > 1)
            {
                parametrs.Add("hints", OSRMApi.CreateAnyUrlParam(Hints));
            }
            if (Exclude != null && Exclude.Count() > 1)
            {
                parametrs.Add("exclude", OSRMApi.CreateAnyUrlParam(Exclude));
            }
            if (SkipWaypoints)
            {
                parametrs.Add("skip_waypoints", SkipWaypoints.ToString());
            }
            if (Snapping != default)
            {
                parametrs.Add("snapping", EnumHelper.ParseEnumToString(Snapping));
            }

            //Child optional params
            var addons = GetAdditionalURLParams();
            if(addons != null)
            {
                parametrs = parametrs.Concat(addons).ToDictionary(x => x.Key, x => x.Value);
            }
            if(parametrs.Count > 0)
                return $"{basedUrl}?{string.Join("&",parametrs.Select(x => x.Key + "=" + x.Value))}";
            else
                return basedUrl;
        }

        //Can be used to make default service
        protected virtual Dictionary<string,string> GetAdditionalURLParams() => null;

        protected async Task<T> Call<T>()
        {
            try
            {
                var request = GetServiceURL();
                var response = await OSRMApi.CallRequest(request);
                return JsonConvert.DeserializeObject<T>(response);
            }
            catch (Exception exception)
            {
                if (Service != null) throw new OSRMException(exception.Message) { Service = (Service)Service };
                else throw new OSRMException(exception.Message);
            }
        }
    }
}
