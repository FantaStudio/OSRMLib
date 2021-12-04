using OSRMLib.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace OSRMLib
{
    public class OSRMApi
    {
        private static HttpClient CreateClient(string adress)
        {
            HttpClient client = new HttpClient() { BaseAddress = new Uri(adress) };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        private static readonly string API_URL = "https://router.project-osrm.org/";
        public static HttpClient GetOSRMClient() => CreateClient(API_URL);

        public static string CreateDoubleUrlParam(IEnumerable<double> doubleParam)
        {
            if(doubleParam == null || doubleParam.Count() < 1)
            {
                return string.Empty;
            }
            return string.Join(";", doubleParam.Select(x => x.ToString("", CultureInfo.InvariantCulture)));
        }

        public static string CreateDoubleUrlParam(IEnumerable<IEnumerable<double>> doubleParam)
        {
            if (doubleParam == null || doubleParam.Count() < 1)
            {
                return string.Empty;
            }
            return string.Join(";", doubleParam.Select(x => string.Join(",",x)));
        }

        public static string CreateAnyUrlParam<T>(IEnumerable<T> anyParam)
        {
            if (anyParam == null || anyParam.Count() < 1)
            {
                return string.Empty;
            }
            return string.Join(";", anyParam.Select(x => x.ToString()));
        }

        public static string CreateAnyUrlParam<T>(IEnumerable<IEnumerable<T>> anyParam)
        {
            if (anyParam == null || anyParam.Count() < 1)
            {
                return string.Empty;
            }
            return string.Join(";", anyParam.Select(x => string.Join(",", x)));
        }

        public static string CreateCoordinatesUrlParam(IEnumerable<Location> locations, bool listOrPolylineFormat = false)
        {
            if (locations == null || locations.Count() < 1)
            {
                return string.Empty;
            }

            if (listOrPolylineFormat)
            {
                return $"polyline({OSRMPolylineConverter.Encode(locations)})";
            }
            else
            {
                return string.Join(";", locations.Select(x => x.Longitude.ToString("", CultureInfo.InvariantCulture)
                        + "," + x.Latitude.ToString("", CultureInfo.InvariantCulture)));
            }
        }

        public static async Task<string> CallRequest(string request)
        {
            try
            {
                var client = GetOSRMClient();
                using (var response = await client.GetAsync(request))
                {
                    return await response.Content.ReadAsStringAsync();
                };
            }
            catch (Exception exception)
            {
                throw new OSRMException(exception.Message);
            }
        }
    }
}
