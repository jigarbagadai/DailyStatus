﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.DataAccessEntities
{
    public class DailyStatusRepository
    {
        internal DatabaseConnection Context;

        public DailyStatusRepository(DatabaseConnection context)
        {
            this.Context = context;
        }

        public virtual List<GetAllRoles_Result> GetAllRoles(int startRecord, int pageSize, string sortColumn, string sortDirection, string searchText, bool status)
        {
            List<GetAllRoles_Result> roles = new List<GetAllRoles_Result>();
            roles = Context.GetAllRoles(startRecord, pageSize, sortColumn, sortDirection, searchText, status).ToList();
            return roles;
        }
    }
}
