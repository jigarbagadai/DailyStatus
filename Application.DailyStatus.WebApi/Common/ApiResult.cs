using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.DailyStatus.WebApi.Common
{
    public class ApiResult
    {
        public Object ResponseData { get; set; }

        public ResponseStatus ResponseStatus { get; set; }

        public Dictionary<string, string> ErrorMessages { get; set; }
    }
}