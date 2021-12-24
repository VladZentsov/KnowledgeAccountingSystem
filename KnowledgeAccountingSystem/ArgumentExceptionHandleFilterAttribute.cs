using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serilog;
using System.Web.Mvc;

namespace KnowledgeAccountingSystem
{
    public class ArgumentExceptionHandleFilterAttribute : IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            Log.Logger.Error(filterContext.Exception.Message);
            if (!filterContext.ExceptionHandled &&
                filterContext.Exception.GetType() == typeof(ArgumentException))
            {
                filterContext.Result = new ContentResult() { Content = "You failed something!" };
                filterContext.ExceptionHandled = true;
            }
        }
    }
}