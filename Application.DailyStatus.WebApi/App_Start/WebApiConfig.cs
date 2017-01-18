using Application.DailyStatus.WebApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Application.DailyStatus.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new LoggingFilterAttribute());
            config.Filters.Add(new ExceptionHandleAtttribute());

            // Web API routes
            config.MapHttpAttributeRoutes();
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "api/v1/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);
        }
    }
}
