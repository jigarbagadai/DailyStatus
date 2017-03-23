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
using System.Transactions;

namespace Application.DailyStatus.BusinessService
{
    public class RoleServices : BaseService, IRoleServices
    {
        public RoleServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public bool DeleteRole(int roleId)
        {
            bool result = false;
            using (var scope = new TransactionScope())
            {
                this.unitOfWork.RoleRepository.Delete(roleId);
                this.unitOfWork.Save();
                scope.Complete();
                result = true;
            }

            return result;
        }

        public List<RoleListEntity> GetAllRole(string roleName, bool status, int skipRecords, int pageSize, string sortDirection, string sortColumn)
        {
            List<GetAllRoles_Result> roles = this.unitOfWork.DailyStatusRepository.GetAllRoles(skipRecords, pageSize, sortColumn, sortDirection, roleName, status).ToList();
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

        public bool SaveRole(RoleEntity role, string modifiedBy)
        {
            bool result = false;

            using (TransactionScope scope = new TransactionScope())
            {
                Role roledb = new Role();
                if (role.RoleId > 0)
                {
                    roledb = this.unitOfWork.RoleRepository.GetByID(role.RoleId);
                }

                roledb.Name = role.RoleName;
                roledb.IsActive = role.IsActive;
                roledb.ModifiedBy = modifiedBy;
                roledb.ModifiedDate = DateTime.UtcNow;

                if (roledb.Id > 0)
                {
                    this.unitOfWork.RoleRepository.Update(roledb);
                }
                else
                {
                    roledb.CreatedBy = modifiedBy;
                    roledb.CreatedDate = DateTime.UtcNow;
                    this.unitOfWork.RoleRepository.Insert(roledb);
                }

                this.unitOfWork.Save();
                scope.Complete();
                result = true;
            }

            return result;
        }
    }
}
