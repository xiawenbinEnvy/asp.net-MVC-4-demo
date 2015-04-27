using Contract.Contract;
using Contract.Request;
using Contract.Response;
using Extension.WebApiExtension;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace MvcUI.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            HttpClientProxy proxy = new HttpClientProxy("http://localhost/webapi/api/");
            NumberResponse response =
                await proxy.Execute(new NumberAddContract() { Request = new NumberRequest() { First = 3, Second = 4 } });
            return Content(response.Result.ToString());
        }
    }
}
