using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WeatherForecast.Controllers;
using System.Threading.Tasks;
using WeatherForecast.Service.Services.Interfaces;
using Moq;
using WeatherForecast.Model.DTOs;
using WeatherForecast.App_Start;
using Newtonsoft.Json;
using WeatherForecast.Service.Services;

namespace WeatherForecast.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        private static object isInitialized = false;
        static HomeControllerTest() {
            lock (isInitialized) {
                if ((bool)isInitialized) return;
                AutoMapperConfiguration.Configure();
                isInitialized = true;
            }
        }

        [TestMethod()]

        public async Task GetWeatherReport_emptyCity_Test()
        {
            var controller = new HomeController(null);
            WeatherDataDTO weatherData = new WeatherDataDTO();

            var result = await controller.GetWeatherReport("") as JsonResult;

            weatherData = JsonConvert.DeserializeObject<WeatherDataDTO>(result.Data.ToString());

            Assert.AreEqual(weatherData.ErrorMessage, "Please specify city name to get the weather forecast.");
        }

        [TestMethod()]
        public async Task GetWeatherReport_invalidCity_MoqTest()
        {
            var service = new Mock<IWeatherForecastService>();
            service.Setup(s => s.GetWeatherByCity("InvalidCity")).Returns(Task.FromResult("{\"cod\":\"502\",\"message\":\"Error: Not found city\"}"));

            var controller = new HomeController(service.Object);
            WeatherDataDTO weatherData = new WeatherDataDTO();

            var result = await controller.GetWeatherReport("InvalidCity") as JsonResult;

            weatherData = JsonConvert.DeserializeObject<WeatherDataDTO>(result.Data.ToString());

            Assert.AreEqual(weatherData.ErrorMessage, "Please specify a valid city name to get the weather forecast.");
        }

        [TestMethod()]
        public async Task GetWeatherReport_invalidCity_Test()
        {
            var service = new WeatherForecastService();

            var controller = new HomeController(service);
            WeatherDataDTO weatherData = new WeatherDataDTO();

            var result = await controller.GetWeatherReport("InvalidCity") as JsonResult;

            weatherData = JsonConvert.DeserializeObject<WeatherDataDTO>(result.Data.ToString());

            Assert.AreEqual(weatherData.ErrorMessage, "Please specify a valid city name to get the weather forecast.");
        }

        [TestMethod()]
        public async Task GetWeatherReport_validCity_MoqTest()
        {
            var service = new Mock<IWeatherForecastService>();
            service.Setup(s => s.GetWeatherByCity("London")).Returns(Task.FromResult("{\"city\" : {\"id\" : 2643743,\"name\" : \"London\",\"coord\" : {	\"lon\" : -0.12574,	\"lat\" : 51.50853},\"country\" : \"GB\",\"population\" : 0,\"sys\" : {	\"population\" : 0}},\"cod\" : \"200\",\"message\" : 0.0045,\"cnt\" : 36,\"list\" : [{	\"dt\" : 1487592000,	\"main\" : {		\"temp\" : 14.7,		\"temp_min\" : 14.05,		\"temp_max\" : 14.7,		\"pressure\" : 1023.78,		\"sea_level\" : 1031.29,		\"grnd_level\" : 1023.78,		\"humidity\" : 82,		\"temp_kf\" : 0.65	},	\"weather\" : [{			\"id\" : 500,			\"main\" : \"Rain\",			\"description\" : \"light rain\",			\"icon\" : \"10d\"		}	],	\"clouds\" : {		\"all\" : 0	},	\"wind\" : {		\"speed\" : 4.82,		\"deg\" : 272	},	\"rain\" : {		\"3h\" : 0.005	},	\"sys\" : {		\"pod\" : \"d\"	},	\"dt_txt\" : \"2017-02-20 12:00:00\"}]}"));

            var controller = new HomeController(service.Object);
            WeatherDataDTO weatherData = new WeatherDataDTO();

            var result = await controller.GetWeatherReport("London") as JsonResult;

            weatherData = JsonConvert.DeserializeObject<WeatherDataDTO>(result.Data.ToString());

            Assert.AreEqual(weatherData.ErrorMessage, "");
            Assert.IsTrue(weatherData.ForecastList.Count > 0);
            Assert.IsTrue(weatherData.CityName.Equals("London"));
        }

        [TestMethod()]
        public async Task GetWeatherReport_validCity_Test()
        {
            var service = new WeatherForecastService(); 

            var controller = new HomeController(service);
            WeatherDataDTO weatherData = new WeatherDataDTO();

            var result = await controller.GetWeatherReport("London") as JsonResult;

            weatherData = JsonConvert.DeserializeObject<WeatherDataDTO>(result.Data.ToString());

            Assert.AreEqual(weatherData.ErrorMessage, "");
            Assert.IsTrue(weatherData.ForecastList.Count > 0);
            Assert.IsTrue(weatherData.CityName.Equals("London"));
        }

        [TestMethod]
        [ExpectedException(typeof(System.NotSupportedException))]
        public void GetWeatherReport_NotSupported_Exception_Test()
        {
            var mock = new Mock<HomeController>();
            mock.Setup(t => t.GetWeatherReport("Liverpool")).Throws(new System.Exception());

            var result = mock.Object.GetWeatherReport("Liverpool");
            
            Assert.Fail("Should have thrown an exception");
        }
    }
}
