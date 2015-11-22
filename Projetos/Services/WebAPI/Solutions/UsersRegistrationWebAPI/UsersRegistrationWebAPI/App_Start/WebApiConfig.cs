using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace UsersRegistrationWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{idUser}/{emailUser}/{passwordUser}/{userRegistration}/{statusUser}",
                defaults: new { idUser = RouteParameter.Optional, emailUser = RouteParameter.Optional, passwordUser = RouteParameter.Optional, userRegistration = RouteParameter.Optional, statusUser = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.Formatters.Insert(0, new Utilities.JsonpFormatter());
        }
    }
}
