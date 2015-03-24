using System;
using System.Diagnostics;
using System.Web.Mvc;

namespace StopwatchActionFilter.Extension
{
    /// <summary>
    /// 自定义计时ActionFilter
    /// </summary>
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class StopwatchFilter : FilterAttribute, IActionFilter
    {
        Stopwatch sw;
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            sw = Stopwatch.StartNew();
        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var time = sw.ElapsedMilliseconds;
            filterContext.RouteData.DataTokens.Add("time", time);
        }
    }
}