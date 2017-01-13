using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.Logging
{
    public interface ILogger
    {
        void Debug(string format, params object[] args);
        void Exception(string format, params object[] args);
        void Exception(Exception ex);
        void Fatal(string format, params object[] args);
        void Info(string format, params object[] args);
        void Trace(string format, params object[] args);
        void Warn(string format, params object[] args);
    }
}
