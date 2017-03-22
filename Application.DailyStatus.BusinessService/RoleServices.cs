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
    public class RoleServices : BaseService, IRoleServices
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
            List<GetAllRoles_Result> roles = this.unitOfWork.DailyStatusRepository.GetAllRoles(skipRecords, pageSize, sortColumn, sortDirection, roleName).ToList();
            List<RoleListEntity> roleList = new List<RoleListEntity>();
            roleList = Mapper.Map<List<GetAllRoles_Result>, List<RoleListEntity>>(roles);
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
            Role role = this.unitOfWork.RoleRepository.GetFirst(m => m.Name == roleName);
            if (role != null && role.Id == roleId)
            {
                return false;
            }
            else if (role != null && role.Id != roleId)
            {
                return true;
            }
            else if (role != null && role.Id == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SaveRole(RoleEntity role)
        {
            throw new NotImplementedException();
        }
    }
}
