using Contract.Contract;
using Extension.WebApiExtension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;

namespace Extension.Tests
{
    /// <summary>
    /// WebApiContractRoute测试类
    /// </summary>
    [TestClass]
    public class WebApiContractRouteTest
    {
        /// <summary>
        /// 正常情况
        /// </summary>
        [TestMethod]
        public void GetRouteDataTest_Normal()
        {
            WebApiContractRoute route = new WebApiContractRoute();
            route.Bind<HomeController>().With<NumberAddContract>();
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("ContractInfo", "NumberAddContract");
            var routeData = route.GetRouteData("", request);
            Assert.AreEqual("home", routeData.Values["controller"]);
            Assert.AreEqual("NumberAdd", routeData.Values["action"]);
        }

        /// <summary>
        /// 未定义Action
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetRouteDataTest_FindNotAction()
        {
            WebApiContractRoute route = new WebApiContractRoute();
            route.Bind<HomeController>().With<NumberSubContract>();
        }

        /// <summary>
        /// 未注册Contract
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GetRouteDataTest_UnRegisterContract()
        {
            WebApiContractRoute route = new WebApiContractRoute();
            route.Bind<HomeController>().With<NumberAddContract>();
            HttpRequestMessage request = new HttpRequestMessage();
            request.Headers.Add("ContractInfo", "NumberMultiContract");
            var routeData = route.GetRouteData("", request);
        }
    }
}
