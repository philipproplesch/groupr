using System.Web.Mvc;
using ServiceStack.Logging;

namespace Groupr.Mvc.Filters
{
    public class HandleExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var log = LogManager.GetLogger(filterContext.Controller.GetType());
            log.Error(filterContext.Exception.ToString());

            base.OnException(filterContext);
        }
    }
}
