using Application.DailyStatus.BusinessEntities;
using Application.DailyStatus.BusinessInterface;
using Application.DailyStatus.WebApi.Authorization;
using Application.DailyStatus.WebApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Application.DailyStatus.WebApi.Controllers
{
    [RoutePrefix("api/v1")]
    public class RoleController : BaseController
    {
        private readonly IRoleServices roleService;

        public RoleController(IRoleServices roleService)
        {
            this.roleService = roleService;
        }

        [DailyStatusAuthorize(Roles = "admin")]
        [Route("Role/{id:int?}")]
        public DailyStatusActionResult Get(int id)
        {
            RoleEntity role = this.roleService.GetRoleById(id);
            return role.ToApiResult();
        }

        [DailyStatusAuthorize(Roles = "admin")]
        [Route("RoleDelete/{id:int?}")]
        [HttpPost]
        public DailyStatusActionResult DeleteRole(int id)
        {
            OKResult result = new OKResult();
            bool deleteResult = this.roleService.DeleteRole(id);
            result = deleteResult.ToOKResult();
            return result.ToApiResult();
        }

        [DailyStatusAuthorize(Roles = "admin")]
        [Route("Roles/{roleName}/{status:bool}/{skipRecords:int}/{sortDirection}/{sortColumn}")]
        public DailyStatusActionResult GetAllRole(string roleName, bool status, int skipRecords, string sortDirection, string sortColumn)
        {
            List<RoleListEntity> roles = this.roleService.GetAllRole(roleName, status, skipRecords, PAGESIZE, sortDirection, sortColumn);
            return roles.ToApiResult();
        }

        [DailyStatusAuthorize(Roles = "admin")]
        [Route("RoleExists/{roleId:int}/{roleName}")]
        [HttpPost]
        public DailyStatusActionResult IsRoleNameExists(int roleId, string roleName)
        {
            OKResult result = new OKResult();
            bool apiresult = this.roleService.IsRoleNameExists(roleId, roleName);
            result = (!apiresult).ToOKResult();
            return result.ToApiResult();
        }

        [DailyStatusAuthorize(Roles="admin")]
        [Route("Roles/Save")]
        [HttpPost]
        public DailyStatusActionResult SaveRole(RoleEntity role)
        {
            OKResult result = new OKResult();
            bool insertResult = this.roleService.SaveRole(role, HttpContext.Current.User.Identity.Name);
            result = insertResult.ToOKResult();
            return result.ToApiResult();
        }
    }
}
