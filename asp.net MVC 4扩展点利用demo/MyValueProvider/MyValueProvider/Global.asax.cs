using System.Web.Mvc;
using System.Web.Routing;
using MyValueProvider.Extension;

namespace MyValueProvider
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //将我们自定义的ValueProvider注册在第一个（也就是最优先被选用）
            ValueProviderFactories.Factories.Insert(0, new MyValueProviderFactory());
        }
    }
}