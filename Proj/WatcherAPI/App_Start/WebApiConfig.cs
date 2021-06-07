using System.Web.Http;
using WatcherAPI.Managers;

namespace WatcherAPI
{
    public static class WebApiConfig
    {
        static SQLManager sqlManager;

        public static void Register(HttpConfiguration config)
        {
            // Конфигурация и службы веб-API

            // Маршруты веб-API
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );
            sqlManager = new SQLManager();
            sqlManager.CreateDB();
        }
    }
}
