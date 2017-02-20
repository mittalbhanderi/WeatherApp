using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WeatherForecast.App_Start;

namespace WeatherForecast
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            IoCConfig.RegisterDependencies();
            AreaRegistration.RegisterAllAreas();
            AutoMapperConfiguration.Configure();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
