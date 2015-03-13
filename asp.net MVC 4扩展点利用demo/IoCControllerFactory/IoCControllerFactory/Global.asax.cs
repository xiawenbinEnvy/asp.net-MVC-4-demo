using System.Web.Mvc;
using System.Web.Routing;
using IoCControllerFactory.Extension;
using IoCControllerFactory.Services;
using Ninject;

namespace IoCControllerFactory
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            IKernel Kernel = new StandardKernel();
            Kernel.Bind<IService>().To<Service>();
            //注册自定义ControllerFactory
            ControllerBuilder.Current.SetControllerFactory(new NinjectControllerFactory(Kernel));
        }
    }
}