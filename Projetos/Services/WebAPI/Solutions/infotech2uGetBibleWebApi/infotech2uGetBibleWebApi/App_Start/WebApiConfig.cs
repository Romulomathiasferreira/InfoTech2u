﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace infotech2uGetBibleWebApi
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
                routeTemplate: "api/{controller}/{idBook}/{initialsBook}/{amountChapterBook}/{amountVerseBook}/{idVersionBook}/{nameFile}/{versionDownload}",
                defaults: new { idBook = RouteParameter.Optional, initialsBook = RouteParameter.Optional, amountChapterBook = RouteParameter.Optional, amountVerseBook = RouteParameter.Optional, idVersionBook = RouteParameter.Optional, nameFile = RouteParameter.Optional, versionDownload = RouteParameter.Optional }
            );

            GlobalConfiguration.Configuration.Formatters.Insert(0, new Utilities.JsonpFormatter());
        }
    }
}
