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

            //This was added for removing complexity of having too many custom attribute routing.
            routes.MapMvcAttributeRoutes();
            //routes.MapRoute(
            //    "AddWatchlistToMember",
            //    "watchlists/member/{mId}/{tId}",
            //    new { controller = "WatchLists", action = "AddNewWatchList" });


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
