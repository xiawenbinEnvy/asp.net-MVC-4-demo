using System.Web.Mvc;
using RangeIfValidation.Models;

namespace RangeIfValidation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ajax(AjaxRequest request)
        {
            string format = "星级{0}价格{1}、类型{2}间数{3}是 {4}合法的";
            if (ModelState.IsValid)
                return Content(string.Format(format, request.Star, request.Price, request.Type, request.Rooms, ""));
            else
                return Content(string.Format(format, request.Star, request.Price, request.Type, request.Rooms, "非"));
        }
    }
}
