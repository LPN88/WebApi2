using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApi2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {           
            // Web API routes
            //Маршрут по умолчанию
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",                
                routeTemplate: "api/{controller}/{action}",               
                defaults: new { controller = "Values", action = "GetTestValues"}
            );            
            //config.Formatters.Insert(0, new JsonSimpleDataFormatter());

        }
    }
}
