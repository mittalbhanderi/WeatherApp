using System;
using AutoMapper;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;
using WeatherForecast.Helpers;
using WeatherForecast.Model.DTOs;
using WeatherForecast.Model.Models;
using static System.StringComparison;
using WeatherForecast.Service.Services.Interfaces;

namespace WeatherForecast.Controllers
{
    public class HomeController : Controller
    {
        private IWeatherForecastService _weatherService;

        public HomeController(IWeatherForecastService weatherService)
        {
            _weatherService = weatherService;
        }
        #region "Action Methods"

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult> GetWeatherReport(string cityName)
        {
            WeatherDataModel weatherData = new WeatherDataModel();
            bool dataRetrieved = false;

            weatherData.ErrorMessage = "Please specify city name to get the weather forecast.";
            // check if cityName is not empty
            if (!string.IsNullOrWhiteSpace(cityName))
            {
                try
                {
                    string result;
                    // get json string result from the service
                    result = await _weatherService.GetWeatherByCity(cityName);
                    if (!string.IsNullOrWhiteSpace(result))
                    {
                        // map json data to our model class
                        // this will be returned as json object to front end
                        weatherData = JsonConvert.DeserializeObject<WeatherDataModel>(result);
                        weatherData.ErrorMessage = "Please specify a valid city name to get the weather forecast.";
                        // check if the correct city weather is returned
                        if (weatherData.City != null)
                        {
                            if (weatherData.City.Name.Equals(cityName, OrdinalIgnoreCase))
                            {
                                weatherData.ErrorMessage = "";
                                dataRetrieved = true;
                            }
                        }
                    }
                    if (!dataRetrieved && string.IsNullOrWhiteSpace(weatherData.ErrorMessage))
                    {
                        weatherData.ErrorMessage = "There was some technical problem getting the weather report. Please try again after sometime.";
                    }
                }
                catch (Exception ex)
                {
                    weatherData.ErrorMessage = $"There was some problem getting the weather report: {ex.Message}";
                }
            }

            return Json(HelperClasses.Json(Mapper.Map<WeatherDataDTO>(weatherData)), JsonRequestBehavior.AllowGet);
           
        }

        #endregion
    }
}