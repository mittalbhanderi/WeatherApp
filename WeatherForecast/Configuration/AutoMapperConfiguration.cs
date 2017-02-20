using AutoMapper;
using WeatherForecast.Model.DTOs;
using WeatherForecast.Model.Models;

namespace WeatherForecast.App_Start
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMissingTypeMaps = true;
                cfg.CreateMap<WeatherDataModel, WeatherDataDTO>()
                .ForMember(t => t.ForecastList, opt => opt.MapFrom(t => t.List));

                cfg.CreateMap<DataDetails, ForecastListDTO>()
                .ForMember(t => t.Day, opt => opt.MapFrom(t => t.Dt_txt.ToString("dddd")))
                .ForMember(t => t.Time, opt => opt.MapFrom(t => t.Dt_txt.ToString("HH:mm")))
                .ForMember(t => t.IconUrl, opt => opt.MapFrom(t => string.Format("http://openweathermap.org/img/w/{0}.png", t.Weather[0].Icon)))
                .ForMember(t => t.WeatherMain, opt => opt.MapFrom(t => t.Weather[0].Main))
                .ForMember(t => t.WeatherDescription, opt => opt.MapFrom(t => t.Weather[0].Description))
                .ForMember(t => t.MainTemp, opt => opt.MapFrom(t => t.Main.Temp))
                .ForMember(t => t.TempMin, opt => opt.MapFrom(t => t.Main.Temp_min))
                .ForMember(t => t.TempMax, opt => opt.MapFrom(t => t.Main.Temp_max))
                .ForMember(t => t.Pressure, opt => opt.MapFrom(t => t.Main.Pressure))
                .ForMember(t => t.Humidity, opt => opt.MapFrom(t => t.Main.Humidity))
                .ForMember(t => t.WindSpeed, opt => opt.MapFrom(t => t.Wind.Speed));
            });
                        

            Mapper.AssertConfigurationIsValid();
        }
    }

}