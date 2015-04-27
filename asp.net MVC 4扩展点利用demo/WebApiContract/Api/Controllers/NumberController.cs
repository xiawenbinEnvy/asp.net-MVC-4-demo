using Contract.Contract;
using Contract.Request;
using Contract.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

namespace Api.Controllers
{
    public class NumberController : ApiController
    {
        public NumberResponse NumberAdd([ModelBinder]NumberRequest request)
        {
            return new NumberResponse() { Result = request.First + request.Second };
        }

        public NumberResponse NumberSub(NumberRequest request)
        {
            return new NumberResponse() { Result = request.First - request.Second };
        }

        [HttpGet]
        public IEnumerable<string> ShowRoute()
        {
            Request.Headers.Add("ContractInfo", "NumberAddContract");
            yield return Configuration.Routes["default"].GetRouteData("", Request).Values["controller"].ToString();
            yield return Configuration.Routes["default"].GetRouteData("", Request).Values["action"].ToString();
        }
    }
}
