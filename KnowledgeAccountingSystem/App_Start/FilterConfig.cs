using System.Web;
using System.Web.Mvc;

namespace KnowledgeAccountingSystem
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ArgumentExceptionHandleFilterAttribute());
            filters.Add(new LoggerFilter());
        }
    }
}
