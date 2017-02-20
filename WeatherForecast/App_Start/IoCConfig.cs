using Autofac;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using WeatherForecast;
using WeatherForecast.Service.Services;
using WeatherForecast.Service.Services.Interfaces;

namespace WeatherForecast.App_Start
{
    public class IoCConfig
    {
        public static void RegisterDependencies() {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<WeatherForecastService>().AsSelf().As<IWeatherForecastService>().InstancePerRequest();
            
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}