using Application.DailyStatus.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.BusinessInterface
{
    public interface IRoleServices
    {
        List<RoleListEntity> GetAllRole(string roleName, bool status, int skipRecords, int pageSize, string sortDirection, string sortColumn);

        void DeleteRole(int roleId);

        RoleEntity GetRoleById(int roleId);

        bool SaveRole(RoleEntity role);

        bool IsRoleNameExists(int roleId, string roleName);
    }
}
