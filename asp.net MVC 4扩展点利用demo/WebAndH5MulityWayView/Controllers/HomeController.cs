using System.Web.Mvc;
using WebAndH5MulityWayView.Extensions;
using WebAndH5MulityWayView.Service;

namespace WebAndH5MulityWayView.Controllers
{
    public class HomeController : Controller
    {
        public IService service = null;

        [MultiwayViewSelectActionFilter("Index")]
        public ActionResult Index()
        {
            //运用了MultiwayViewSelectActionFilter，就不需要在action内写辨别h5还是web的逻辑。
            //选择view的逻辑收口到过滤器里，便于应变变化
            var name = service.Name();
            return View((object)name);
        }
    }
}
