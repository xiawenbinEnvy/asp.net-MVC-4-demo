using System;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyModelBinder
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            HttpRuntime.Cache["time"] = DateTime.Now;
        }
    }
}