using Application.DailyStatus.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.DailyStatus.WebApi.Helper
{
    public class LoggerHelper
    {
        private static ILogger loggerobj;

        private LoggerHelper()
        {
        }

        public static ILogger GetLogger()
        {
            if(loggerobj == null)
            {
                loggerobj = new NLogger();
            }

            return loggerobj;
        }
    }
}