using Api.Controllers;
using Contract.Contract;
using Extension.WebApiExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Api
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var route = new WebApiContractRoute();
            route.Bind<NumberController>().With<NumberAddContract>().With<NumberSubContract>();

            config.Routes.Add("singleEntryRoute", route);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
