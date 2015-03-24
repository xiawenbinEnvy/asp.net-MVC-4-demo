using System.Web;
using System.Web.Mvc;

namespace MyModelBinder.Extension
{
    /// <summary>
    /// 自定义一个ModelBinder，从缓存内取数据
    /// </summary>
    public class CacheModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            return HttpRuntime.Cache["time"];
        }
    }
}