using System;
using System.Web.Mvc;
using System.Web.Routing;
using Ninject;

namespace IoCControllerFactory.Extension
{
    /// <summary>
    /// 自定义ControllerFactory，实现依赖类型的DI
    /// </summary>
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        public IKernel Kernel { get; private set; }

        public NinjectControllerFactory(IKernel Kernel)
        {
            this.Kernel = Kernel;
        }
        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {
            return this.Kernel.TryGet(controllerType) as IController;
        }
    }
}