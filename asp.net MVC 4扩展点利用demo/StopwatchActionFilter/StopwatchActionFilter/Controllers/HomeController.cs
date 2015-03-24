using System.Threading;
using System.Web.Mvc;
using StopwatchActionFilter.Extension;

namespace StopwatchActionFilter.Controllers
{
    public class HomeController : Controller
    {
        [StopwatchFilter]
        public ActionResult Index()
        {
            Thread.Sleep(5000);//模拟耗时
            return View();
        }

    }
}
