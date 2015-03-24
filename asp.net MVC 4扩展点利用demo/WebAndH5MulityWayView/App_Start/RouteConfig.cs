using System.Web.Mvc;
using System.Web.Routing;

namespace WebAndH5MulityWayView
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{viewtype}",
                defaults: new { viewType = "", controller = "Home", action = "Index" }
            );
        }
    }
}