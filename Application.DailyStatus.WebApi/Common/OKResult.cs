using Application.DailyStatus.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.DailyStatus.WebApi.Common
{
    public class OKResult : BaseEntity
    {
        public string ResultCode { get; set; }
    }
}