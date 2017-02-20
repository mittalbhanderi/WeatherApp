using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherForecast.Service.Services.Interfaces;

namespace WeatherForecast.Service.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        #region "Constants"

        private const string URL = "http://api.openweathermap.org/data/2.5/forecast/city";
        private const string urlParameters = "?units=metric&q=";
        private const string APIKEY = "&APPID=ba06e17739cc00aa485c85157fe8487d";

        #endregion
        public async Task<string> GetWeatherByCity(string cityName)
        {
            string returnString = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(URL);

                // set request headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var response = await client.GetAsync(string.Concat(urlParameters, cityName, APIKEY)))
                {
                    returnString = await response.Content.ReadAsStringAsync();
                }
            }
            return returnString;
        }
    }
}
