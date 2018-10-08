using System.Web.Http;

namespace WebServices_DBConnectivity
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
               name: "Api_Get",
               routeTemplate: "{controller}/{action}",
               defaults: new { controller = "Employee", action = "GetEmployees" }
            );

            config.Routes.MapHttpRoute(
               name: "Api_Post",
               routeTemplate: "{controller}/{action}",
               defaults: new { controller = "Employee", action = "InsertEmployee" }
            );
        }
    }
}
