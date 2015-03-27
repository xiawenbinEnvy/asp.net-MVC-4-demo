using System.Web.Mvc;
using System.Web.Routing;

namespace MultiPartialViewSelect
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{channel}",
                defaults: new { controller = "Home", action = "Index", channel = UrlParameter.Optional }
            );
        }
    }
}