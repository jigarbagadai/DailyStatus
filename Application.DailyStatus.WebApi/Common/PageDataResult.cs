using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.DailyStatus.WebApi.Common
{
    public class PageDataResult
    {
        public int TotalRecords { get; set; }

        public int CurrentPageNumber { get; set; }

        public string SortKey { get; set; }

        public string SortDirection { get; set; }

        public object Data { get; set; }
    }
}