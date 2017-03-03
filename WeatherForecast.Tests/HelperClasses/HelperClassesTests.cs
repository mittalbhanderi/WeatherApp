using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Helpers;
using WeatherForecast.Model.DTOs;

namespace WeatherForecast.Tests.HelperClassesTests
{
    [TestClass]
    public class HelperClassesTests
    {
        [TestMethod]
        public void Json_Empty_Object_test() {
            var result = HelperClasses.Json(null);
            Assert.AreEqual(result, String.Empty);
        }

        [TestMethod]
        public void Json_Object_To_Json_Test() {
            var testObject = new
            {
                City = "London",
                Country = "GB",
                Weather = "Always Changing",
                MaxTemp = 10,
                MinTemp = 6
            };
            var result = HelperClasses.Json(testObject);
            Assert.AreEqual(result, "{\r\n  \"city\": \"London\",\r\n  \"country\": \"GB\",\r\n  \"weather\": \"Always Changing\",\r\n  \"maxTemp\": 10,\r\n  \"minTemp\": 6\r\n}");
        }

        [TestMethod]
        public void Json_Dto_To_Json_Test()
        {
            var testDto = new WeatherDataDTO
            {
               CityName = "Basingstoke",
               ErrorMessage = "",
               ForecastList = new List<ForecastListDTO>() {
                   new ForecastListDTO { Day="Monday", Humidity= 70, MainTemp=10, WindSpeed= 3.8m, TempMax=12.4m, TempMin=6.5m }
               }
            };
            var result = HelperClasses.Json(testDto);
            Assert.AreEqual(result, "{\r\n  \"errorMessage\": \"\",\r\n  \"cityName\": \"Basingstoke\",\r\n  \"forecastList\": [\r\n    {\r\n      \"day\": \"Monday\",\r\n      \"mainTemp\": 10.0,\r\n      \"tempMin\": 6.5,\r\n      \"tempMax\": 12.4,\r\n      \"pressure\": 0.0,\r\n      \"humidity\": 70,\r\n      \"windSpeed\": 3.8\r\n    }\r\n  ]\r\n}");
        }
    }
}
