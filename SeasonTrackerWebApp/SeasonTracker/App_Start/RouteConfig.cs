using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SeasonTracker
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //This was added for removing complexity of having too many custom attribute routing for MVC controllers.
            //With this enabled, a custom route can be defined within the controller that controls the view, like:
            //[Route("watchlists/add/{mId}/{tId}")]
            routes.MapMvcAttributeRoutes();

            //This is what a custom route looks like, but not needed if the above is enabled
            //routes.MapRoute(
            //    "AddWatchlistToMember",
            //    "watchlists/member/{mId}/{tId}",
            //    new { controller = "WatchLists", action = "AddNewWatchList" });

            //Important information on API routing:
            //https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/routing-in-aspnet-web-api

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
