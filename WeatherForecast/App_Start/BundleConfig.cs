using System.Web.Optimization;

namespace WeatherForecast.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {            

            bundles.Add(new ScriptBundle("~/bundles/WeatherApp").
                Include("~/Scripts/WeatherApp.js").
                IncludeDirectory("~/Scripts/services", "*.js").
                IncludeDirectory("~/Scripts/controllers", "*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/weather.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}