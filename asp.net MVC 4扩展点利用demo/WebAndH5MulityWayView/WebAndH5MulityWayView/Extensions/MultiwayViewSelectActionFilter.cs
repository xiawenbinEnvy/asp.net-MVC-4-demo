using System.Web.Mvc;

namespace WebAndH5MulityWayView.Extensions
{
    public class MultiwayViewSelectActionFilter : ActionFilterAttribute
    {
        private string viewName;
        public MultiwayViewSelectActionFilter(string viewName)
        {
            this.viewName = viewName;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext == null) return;
            if (string.IsNullOrEmpty(viewName)) return;

            ViewResult viewResult = filterContext.Result as ViewResult;
            PartialViewResult partialviewResult = filterContext.Result as PartialViewResult;
            if (viewResult == null && partialviewResult == null) return;

            string requestViewType = filterContext.HttpContext.Request != null ? filterContext.HttpContext.Request["viewType"] : "";
            if (requestViewType == null) requestViewType = "";
            string routeViewType = filterContext.RouteData.Values.ContainsKey("viewType") ? filterContext.RouteData.Values["viewType"].ToString() : "";
            if (string.IsNullOrEmpty(requestViewType) && string.IsNullOrEmpty(routeViewType)) return;
            if (requestViewType.ToLower() != "h5" && routeViewType.ToLower() != "h5") return;

            var h5ViewPath = "h5/" + viewName;
            if (viewResult != null)
            {
                filterContext.Result = new ViewResult
                {
                    TempData = viewResult.TempData,
                    ViewData = viewResult.ViewData,
                    ViewName = h5ViewPath
                };
            }
            else if (partialviewResult != null)
            {
                filterContext.Result = new PartialViewResult
                {
                    TempData = viewResult.TempData,
                    ViewData = viewResult.ViewData,
                    ViewName = h5ViewPath
                };
            }
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            
        }
    }
}