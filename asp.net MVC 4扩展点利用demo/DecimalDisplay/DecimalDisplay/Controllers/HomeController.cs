using System.Web.Mvc;
using DecimalDisplay.Models;

namespace DecimalDisplay.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            HotelInfo model = new HotelInfo() { Price = 3.5M };
            return View(model);
        }

    }
}
