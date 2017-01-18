using Application.DailyStatus.WebApi.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Newtonsoft;
using Newtonsoft.Json;

namespace Application.DailyStatus.WebApi.Filters
{
    public class LoggingFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext filterContext)
        {
            string message = "Controller Name: {0}, Action Name: {1}, Filter Argument: {2}";
            LoggerHelper.GetLogger().Info(message, filterContext.ControllerContext.ControllerDescriptor.ControllerType.FullName, filterContext.ActionDescriptor.ActionName, JsonConvert.SerializeObject(filterContext.ActionArguments));
        }
    }
}