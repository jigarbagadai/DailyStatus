using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.DailyStatus.WebApi.Common
{
    public enum ResponseStatus
    {
        Sucess = 0,
        Fail = 1,
        NotFound = 2,
        ValidationError = 3
    }
}