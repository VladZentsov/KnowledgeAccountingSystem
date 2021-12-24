using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace KnowledgeAccountingSystem
{
    public class LoggerFilter : IActionFilter
    {
        static LoggerFilter()
        {
            Log.Logger = new LoggerConfiguration()
              .ReadFrom.AppSettings()
              .CreateLogger();
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var logInfo = GetInfo(filterContext.RouteData.Values);
            Log.Logger.Information(logInfo);
        }

        private string GetInfo(RouteValueDictionary routeDictionary)
        {
            var stringBuilder = new StringBuilder(string.Empty);
            foreach (var item in routeDictionary)
            {
                stringBuilder.Append(item + "/");
            }

            return stringBuilder.ToString();
        }
    }
}