using System.Web.Mvc;
using System.Web.Routing;

namespace VoteSystem.Clients.MVC
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Culture",
               url: "{lang}/{controller}/{action}",
               defaults: new { controller = "Introduction", action = "Index" },
               constraints: new {lang = "bg|en"});

            routes.MapRoute(
                name: "Intro",
                url: "{controller}/{action}",
                defaults: new { controller = "Introduction", action = "Index" });
        }
    }
}
