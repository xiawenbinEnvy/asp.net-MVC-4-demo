using Contract.Request;
using Contract.Response;
using System.Web.Http;

namespace Api.Controllers
{
    public class NumberController : ApiController
    {
        public NumberResponse NumberAdd(NumberRequest request)
        {
            return new NumberResponse() { Result = request.First + request.Second };
        }

        public NumberResponse NumberSub(NumberRequest request)
        {
            return new NumberResponse() { Result = request.First - request.Second };
        }
    }
}
