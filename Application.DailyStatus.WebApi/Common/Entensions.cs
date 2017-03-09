﻿using Application.DailyStatus.BusinessEntities;
using Application.DailyStatus.WebApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application.DailyStatus.WebApi
{
    public static class Entensions
    {
        public static DailyStatusActionResult ToApiResult(this BaseEntity baseEntity)
        {
            if (baseEntity != null)
            {
                return new DailyStatusActionResult(baseEntity, ResponseStatus.Sucess);
            }
            else
            {
                List<string> errorMessage = new List<string>();
                errorMessage.Add("Entity Not Exists");
                return new DailyStatusActionResult(errorMessage, ResponseStatus.NotFound);
            }
        }
    }
}