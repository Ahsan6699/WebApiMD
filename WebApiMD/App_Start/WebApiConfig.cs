using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApiMD
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
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );


			//JsonConvert.DefaultSettings = () => new JsonSerializerSettings
			//{
			//	Formatting = Newtonsoft.Json.Formatting.Indented,
			//	ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
			//};


			var jsonFormatter = config.Formatters.JsonFormatter;

            jsonFormatter.Indent = true;
            jsonFormatter.SerializerSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
		}
    }
}
