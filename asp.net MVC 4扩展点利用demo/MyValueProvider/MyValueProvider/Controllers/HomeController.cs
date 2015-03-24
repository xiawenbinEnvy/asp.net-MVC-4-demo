using System.Web.Mvc;

namespace MyValueProvider.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ajax(int id, string other)
        {
            return Content(string.Format("获取到的id参数值为{0}（来自于route），other数据为{1}（来自于form）", id, other));
        }
    }
}
