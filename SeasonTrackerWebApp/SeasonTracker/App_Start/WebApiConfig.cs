using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace SeasonTracker
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //This is added to change the API data from XML to JSON camelCase.
            //Test using the POSTMAN chrome extension to send something like https://localhost:44398/api/customers
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;

            //This was added for removing complexity of having too many custom attribute routing for api controllers.
            //With this enabled, a custom route can be defined within the api controller that controls the view, like:
            //[Route("api/watchlists/member/{mId}")]
            config.MapHttpAttributeRoutes();

            //Important information on API routing:
            //https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/routing-in-aspnet-web-api

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
