﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace EncryptCryptographyServiceWebAPI
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
                routeTemplate: "api/{controller}/{Entrada}",
                defaults: new { Entrada = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.Formatters.Insert(0, new Util.JsonpFormatter());
        }
    }
}
