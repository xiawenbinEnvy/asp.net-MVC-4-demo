using System;
using System.Web.Mvc;
using MyModelBinder.Extension;

namespace MyModelBinder.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index([ModelBinder(typeof(CacheModelBinder))]
            DateTime time)
        {
            return Content(
                string.Format("从自定义ModelBinder中取的系统启动时间{0}，当前时间为{1}，无论刷新多少次，启动时间都不变", 
                time, DateTime.Now));
        }
    }
}
