using System.Web.Mvc;
using System.Web.Routing;

namespace VoteSystem.Clients.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    "SpecificRoute", 
            //    "{action}", 
            //    new { controller = "Introduction", action = "Index"});

            //routes.MapRoute(
            //   "SpecificRoute2",
            //   "{controller}",
            //   new { controller = "Introduction", action = "Index" });

            routes.MapRoute(
                name: "Intro",
                url: "{controller}/{action}",
                defaults: new { controller = "Introduction", action = "Index" });

            //routes.MapRoute(
            //   name: "Default",
            //   url: "{controller}/{action}",
            //   defaults: new { controller = "Introduction", action = "Intro"});
        }
    }
}
