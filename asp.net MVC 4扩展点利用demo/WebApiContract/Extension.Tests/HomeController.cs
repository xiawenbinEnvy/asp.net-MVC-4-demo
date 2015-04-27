using Contract.Contract;
using Contract.Request;
using Contract.Response;
using System.Web.Http;

namespace Extension.Tests
{
    public class HomeController : ApiController
    {
        public NumberResponse NumberAdd(NumberRequest request)
        {
            return new NumberResponse() { Result = request.First + request.Second };
        }
    }
}
