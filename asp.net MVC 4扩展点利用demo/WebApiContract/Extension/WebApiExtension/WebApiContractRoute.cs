using Contract.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Routing;

namespace Extension.WebApiExtension
{
    /// <summary>
    /// 对IHttpRoute对象的扩展：
    /// 一个HttpRoute和一个Controller绑定，通过契约和Action绑定
    /// 提供强类型路由
    /// </summary>
    public class WebApiContractRoute : HttpRoute
    {
        /// <summary>
        /// 当前Bind的Controller
        /// </summary>
        private static Type lastControllerType = null;

        /// <summary>
        /// 保存契约、Controller和Action的对应关系
        /// </summary>
        private static Dictionary<string, Tuple<string, string>> Map = null;

        /// <summary>
        /// 静态构造函数
        /// </summary>
        static WebApiContractRoute()
        {
            Map = new Dictionary<string, Tuple<string, string>>();
        }

        /// <summary>
        /// 为WebApiContractRoute绑定控制器
        /// </summary>
        /// <typeparam name="TController">Controller类型</typeparam>
        /// <returns>WebApiContractRoute</returns>
        public WebApiContractRoute Bind<TController>()
            where TController : ApiController
        {
            lastControllerType = typeof(TController);
            return this;
        }

        /// <summary>
        /// 注册契约到通过Bind选择的控制器上
        /// </summary>
        /// <typeparam name="TContract">契约类型</typeparam>
        /// <returns>WebApiContractRoute</returns>
        public WebApiContractRoute With<TContract>()
            where TContract : IContract
        {
            if (lastControllerType == null)
                throw new Exception("请先绑定Controller");

            string contractName = typeof(TContract).Name;
            if (!contractName.EndsWith("contract", true, null))
                throw new Exception("约定契约类型以Contract结尾");
            contractName = contractName.ToLower().Replace("contract", "");
            if (Map.ContainsKey(contractName))
                throw new Exception("契约类型名称请勿有重复");

            string controllerName = lastControllerType.Name.ToLower().Replace("controller", "");

            MethodInfo action = lastControllerType
               .GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly)
               .FirstOrDefault(b => b.Name.ToLower() == contractName);
            if (action == null)
                throw new Exception("根据Controller和Contract未找到Action，请检查：Action名约定应该和契约名去除结尾的Contract相同");
            string actionName = action.Name;

            var item = Tuple.Create(controllerName, actionName);
            Map.Add(contractName, item);

            return this;
        }

        public override IHttpRouteData GetRouteData(string virtualPathRoot, HttpRequestMessage request)
        {
            if (request == null || request.Headers == null)
                throw new ArgumentNullException("HttpRequestMessage不能为空");

            var contract = request.Headers.FirstOrDefault(b => b.Key == "ContractInfo");
            if (contract.Value == null)
                throw new Exception("请通过HttpClientProxy，以传递Contract的方式来进行WebApi调用");

            string contractName = contract.Value.FirstOrDefault();
            if (string.IsNullOrEmpty(contractName))
                throw new Exception("请通过HttpClientProxy，以传递Contract的方式来进行WebApi调用");

            contractName = contractName.ToLower().Replace("contract", "");
            var map = Map.FirstOrDefault(t => t.Key == contractName);
            if (map.Value == null)
                throw new Exception("未查找到Contract");

            var routeData = new HttpRouteData(this);
            routeData.Values.Add("controller", map.Value.Item1);
            routeData.Values.Add("action", map.Value.Item2);

            return routeData;
        }
    }
}
