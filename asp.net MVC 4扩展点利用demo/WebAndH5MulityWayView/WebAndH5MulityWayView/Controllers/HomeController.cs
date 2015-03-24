using System.Web.Mvc;
using WebAndH5MulityWayView.Extensions;

namespace WebAndH5MulityWayView.Controllers
{
    public class HomeController : Controller
    {
        [MultiwayViewSelectActionFilter("Index")]
        public ActionResult Index()
        {
            //运用了MultiwayViewSelectActionFilter，就不需要在action内写辨别h5还是web的逻辑。
            //选择view的逻辑收口到过滤器里，便于应变变化
            int i = 9999;
            return View(i);
        }
    }
}
