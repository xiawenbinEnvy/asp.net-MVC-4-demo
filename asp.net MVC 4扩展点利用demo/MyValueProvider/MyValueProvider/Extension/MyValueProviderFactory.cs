using System.Collections.Generic;
using System.Globalization;
using System.Web.Mvc;

namespace MyValueProvider.Extension
{
    /// <summary>
    /// 自定义ValueProvider，实现功能：
    /// 如果route、queryString、form里，都有叫同一个名字的参数的话，
    /// 以route数据为主
    /// </summary>
    public class MyValueProviderFactory:ValueProviderFactory
    {
        public override IValueProvider GetValueProvider(ControllerContext controllerContext)
        {
            var routeData = controllerContext.RequestContext.RouteData.Values;//路由数据
            var queryString = controllerContext.HttpContext.Request.QueryString.AllKeys;//queryString数据
            var formData = controllerContext.HttpContext.Request.Form.AllKeys;//form数据

            Dictionary<string, object> dic = new Dictionary<string, object>();
            foreach (var q in queryString)
            {
                if (!dic.ContainsKey(q))
                    dic.Add(q, controllerContext.HttpContext.Request.QueryString.GetValues(q));
            }
            foreach (var f in formData)
            {
                if (!dic.ContainsKey(f))
                    dic.Add(f, controllerContext.HttpContext.Request.Form.GetValues(f));
            }
            foreach (var r in routeData)
            {
                if (!dic.ContainsKey(r.Key)) dic.Add(r.Key, r.Value);
                else dic[r.Key] = r.Value;
            }
            return new DictionaryValueProvider<object>(dic, CultureInfo.CurrentCulture);
        }
    }
}