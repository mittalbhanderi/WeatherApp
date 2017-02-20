using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace WeatherForecast.Helpers
{
    public static class HelperClasses
    {
        public static string Json(Object data) {
            var jsonSerializerSettings = new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                DateTimeZoneHandling = DateTimeZoneHandling.Local
            };

            return JsonConvert.SerializeObject(data, Formatting.Indented, jsonSerializerSettings);

        }
    }
}