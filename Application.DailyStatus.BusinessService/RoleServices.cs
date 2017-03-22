using Application.DailyStatus.BusinessEntities;
using Application.DailyStatus.BusinessInterface;
using Application.DailyStatus.DataAccessEntities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DailyStatus.DataAccessInterface;

namespace Application.DailyStatus.BusinessService
{
    public class RoleServices:BaseService, IRoleServices
    {
        public RoleServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public void DeleteRole(int roleId)
        {
            this.unitOfWork.RoleRepository.Delete(roleId);
            this.unitOfWork.Save();
        }

        public List<RoleListEntity> GetAllRole(string roleName, bool status, int skipRecords, int pageSize, string sortDirection, string sortColumn)
        {
           List<GetAllRoles_Result> roles = this.unitOfWork.DailyStatusRepository.GetAllRoles(skipRecords,pageSize,sortColumn,sortDirection,roleName).ToList();
           List<RoleListEntity> roleList = new List<RoleListEntity>();
            //roleList = Mapper.Map<User, UserEntity>(roleList);
            return roleList;
        }

        public RoleEntity GetRoleById(int roleId)
        {
            Role role = this.unitOfWork.RoleRepository.GetByID(roleId);
            if (role != null)
            {
                RoleEntity roleEntity = new RoleEntity();
                roleEntity = Mapper.Map<Role, RoleEntity>(role);
                return roleEntity;
            }

            return null;
        }

        public bool IsRoleNameExists(int roleId, string roleName)
        {
            throw new NotImplementedException();
        }

        public bool SaveRole(RoleEntity role)
        {
            throw new NotImplementedException();
        }
    }
}
