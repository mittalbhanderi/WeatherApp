using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Model.DTOs
{
    public class WeatherDataDTO
    {
        public string ErrorMessage { get; set; }
        public string CityName { get; set; }
        public List<ForecastListDTO> ForecastList { get; set; }

    }

    public class ForecastListDTO {

        public string Day { get; set; }
        public string Time { get; set; }
        public string IconUrl { get; set; }
        public string WeatherMain { get; set; }
        public string WeatherDescription { get; set; }
        public decimal MainTemp { get; set; }
        public decimal TempMin { get; set; }
        public decimal TempMax { get; set; }
        public decimal Pressure { get; set; }
        public int Humidity { get; set; }
        public decimal WindSpeed { get; set; }

    }
}
