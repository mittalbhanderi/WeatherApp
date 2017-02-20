using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Model.Models
{
    public class WeatherDataModel
    {
        public CityDetails City { get; set; }
        public string Cod { get; set; }
        public string Message { get; set; }
        public int Cnt { get; set; }
        public List<DataDetails> List { get; set; }
        public string ErrorMessage { get; set; } = "Please specify city name to get the weather forecast.";
    }

    public class CityDetails
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public CoOrdinates Coord { get; set; }
        public string Country { get; set; }
        public int Population { get; set; }
        public SysDetails Sys { get; set; }
    }

    public class CoOrdinates
    {
        public double Lon { get; set; }
        public double Lat { get; set; }
    }

    public class SysDetails
    {
        public int Population { get; set; }
        public string Pod { get; set; }
    }

    public class DataDetails
    {
        public int Dt { get; set; }
        public MainDetails Main { get; set; }
        public List<WeatherDetails> Weather { get; set; }
        public CloudDetails Clouds { get; set; }
        public WindDetails Wind { get; set; }
        public SysDetails Sys { get; set; }

        public DateTime Dt_txt { get; set; }

        //    public string forecastDate
        //    {
        //        get
        //        {
        //            DateTime tempDate;
        //            if (DateTime.TryParse(_dt_txt, out tempDate))
        //            {
        //                return tempDate.ToString("dd/MM/yyyy HH:mm");
        //            }
        //            return _dt_txt;
        //        }
        //    }

        //    public string forecastDay
        //    {
        //        get
        //        {
        //            DateTime tempDate;
        //            if (DateTime.TryParse(_dt_txt, out tempDate))
        //            {
        //                return tempDate.ToString("dddd");
        //            }
        //            return string.Empty;
        //        }
        //    }

        //    public string forecastTime
        //    {
        //        get
        //        {
        //            DateTime tempDate;
        //            if (DateTime.TryParse(_dt_txt, out tempDate))
        //            {
        //                return tempDate.ToString("HH:mm");
        //            }
        //            return string.Empty;
        //        }
        //    }
    }

    public class MainDetails
    {
        public decimal Temp { get; set; }
        public decimal Temp_min { get; set; }
        public decimal Temp_max { get; set; }
        public decimal Pressure { get; set; }
        public decimal Sea_level { get; set; }
        public decimal Grnd_level { get; set; }
        public int Humidity { get; set; }
        public decimal Temp_kf { get; set; }
    }

    public class WeatherDetails
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }

    public class CloudDetails
    {
        public int All { get; set; }
    }
    public class WindDetails
    {
        public decimal Speed { get; set; }
        public decimal Deg { get; set; }
    }

}