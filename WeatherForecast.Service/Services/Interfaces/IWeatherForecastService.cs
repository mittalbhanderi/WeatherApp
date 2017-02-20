using System.Threading.Tasks;
using WeatherForecast.Model.Models;

namespace WeatherForecast.Service.Services.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<string> GetWeatherByCity(string cityName);
    }
}
