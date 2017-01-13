using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.Logging
{
    public class NLogger : ILogger
    {
        private readonly Logger logger;

        public NLogger()
        {
            logger = LogManager.GetLogger("applicationLogger");
        }

        public void Debug(string format, params object[] args)
        {
            this.logger.Debug(format, args);
        }

        public void Exception(Exception ex)
        {
            this.logger.Error(ex);
        }

        public void Exception(string format, params object[] args)
        {
            this.logger.Error(format, args);
        }

        public void Fatal(string format, params object[] args)
        {
            this.logger.Fatal(format, args);
        }

        public void Info(string format, params object[] args)
        {
            this.logger.Info(format, args);
        }

        public void Trace(string format, params object[] args)
        {
            this.logger.Trace(format, args);
        }

        public void Warn(string format, params object[] args)
        {
            this.logger.Warn(format, args);
        }
    }
}
