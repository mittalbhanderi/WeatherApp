using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using WeatherForecast.Service.Services.Interfaces;

namespace WeatherForecast.Service.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        public async Task<string> GetWeatherByCity(string cityName)
        {
            string returnString = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["URL"]);

                // set request headers
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var response = await client.GetAsync($"?units=metric&q={cityName}&APPID={ConfigurationManager.AppSettings["APIKEY"]}"))
                {
                    returnString = await response.Content.ReadAsStringAsync();
                }
            }
            return returnString;
        }
    }
}
