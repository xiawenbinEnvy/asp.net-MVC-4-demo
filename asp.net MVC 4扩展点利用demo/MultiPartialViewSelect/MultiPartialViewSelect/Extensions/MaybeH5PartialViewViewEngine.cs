using System.IO;
using System.Web.Mvc;

namespace MultiPartialViewSelect.Extensions
{
    public class MaybeH5PartialViewViewEngine : RazorViewEngine
    {
        public override ViewEngineResult FindPartialView(ControllerContext controllerContext, string partialViewName, bool useCache)
        {
            string channel = controllerContext.RouteData.Values.ContainsKey("channel") ? 
                controllerContext.RouteData.GetRequiredString("channel") : "";
            if (!string.IsNullOrEmpty(channel) && channel == "h5")
            {
                string controllerName = controllerContext.RouteData.GetRequiredString("controller");
                string h5ViewPath = string.Format("~/views/{0}/h5/{1}.cshtml", controllerName, partialViewName);
                string fileName = controllerContext.HttpContext.Request.MapPath(h5ViewPath);
                if (File.Exists(fileName))
                {
                    return new ViewEngineResult(
                        new RazorView(controllerContext, h5ViewPath, null, false, null), this);
                }
            }
            return base.FindPartialView(controllerContext, partialViewName, useCache);
        }

        public override ViewEngineResult FindView(ControllerContext controllerContext, string viewName, string masterName, bool useCache)
        {
            return base.FindView(controllerContext, viewName, masterName, useCache);
        }

        public override void ReleaseView(ControllerContext controllerContext, IView view)
        {
            base.ReleaseView(controllerContext, view);
        }
    }
}