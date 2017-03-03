using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WeatherForecast.Helpers
{
    public static class HelperClasses
    {
        public static string Json(Object data) {
            string returnString = string.Empty;
            if (data != null)
            {
                var jsonSerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore,
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    DateTimeZoneHandling = DateTimeZoneHandling.Local
                };

                returnString = JsonConvert.SerializeObject(data, Formatting.Indented, jsonSerializerSettings);
            }
            return returnString;
        }
    }
}