using System.Web.Mvc;
using IoCControllerFactory.Services;
using Ninject;

namespace IoCControllerFactory.Controllers
{
    public class HomeController : Controller
    {
        [Inject]
        public IService service { get; set; }

        public ActionResult Index()
        {
            return Content(
                string.Format("依赖IoC之后，未手工new的Service是否为null？{0}。service.Do()的值为{1}",
                this.service == null ? "yes" : "no", this.service.Do()));
        }
    }
}
