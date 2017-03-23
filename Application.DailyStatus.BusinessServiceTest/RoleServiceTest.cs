using Application.DailyStatus.BusinessCommon;
using Application.DailyStatus.BusinessEntities;
using Application.DailyStatus.BusinessInterface;
using Application.DailyStatus.BusinessService;
using Application.DailyStatus.DataAccessEntities;
using Application.DailyStatus.DataAccessInterface;
using Application.DailyStatus.MockData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.BusinessServiceTest
{
    [TestClass]
    public class RoleServiceTest
    {
        private IRoleServices roleService;
        private IUnitOfWork unitOfWork;
        private List<Role> roles;
        private List<GetAllRoles_Result> roleList;
        private GenericRepository<Role> roleRepository;
        private DailyStatusRepository dailyStatusRepository;
        private DatabaseConnection dbEntities;

        [TestInitialize]
        public void Setup()
        {
            roles = DataInitializer.GetRoles();
            roleList = DataInitializer.GetRoleList();
            dbEntities = new Mock<DatabaseConnection>().Object;
            roleRepository = SetUpRoleRepository();
            dailyStatusRepository = SetupDailyRepositry();
            var mokcunitOfWork = new Mock<IUnitOfWork>();
            mokcunitOfWork.SetupGet(s => s.RoleRepository).Returns(roleRepository);
            mokcunitOfWork.SetupGet(s => s.DailyStatusRepository).Returns(dailyStatusRepository);
            unitOfWork = mokcunitOfWork.Object;
            roleService = new RoleServices(unitOfWork);
            MapperConfiguration.IntlializeMapperConfiguration();
        }

        private DailyStatusRepository SetupDailyRepositry()
        {
            var mockRepo = new Mock<DailyStatusRepository>(MockBehavior.Default, dbEntities);
            mockRepo.Setup(p => p.GetAllRoles(It.IsAny<int>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(),It.IsAny<bool>())).Returns(
                    roleList
                );
            return mockRepo.Object;
        }

        private GenericRepository<Role> SetUpRoleRepository()
        {
            var mockRepo = new Mock<GenericRepository<Role>>(MockBehavior.Default, dbEntities);
            mockRepo.Setup(p => p.GetByID(It.IsAny<int>())).Returns(new Func<int, Role>(id => roles.Find(p => p.Id.Equals(id))));
            mockRepo.Setup(p => p.Delete(It.IsAny<object>())).Callback((object roleId) =>
            {
                roles.Remove(roles.FirstOrDefault(m => m.Id == (int)roleId));
            });

            mockRepo.Setup(p => p.Insert((It.IsAny<Role>()))).Callback(new Action<Role>(newRole =>
            {
                int maxRoleID = roles.Last().Id;
                int nextRoleID = maxRoleID + 1;
                newRole.Id = nextRoleID;
                roles.Add(newRole);
            }));

            mockRepo.Setup(p => p.Update(It.IsAny<Role>())).Callback(new Action<Role>(role =>
            {
                var oldRole = roles.Find(a => a.Id == role.Id);
                oldRole = role;
            }));

            return mockRepo.Object;
        }

        [TestMethod]
        public void GetRoleByIdTest()
        {
            Role role = this.unitOfWork.RoleRepository.GetByID(1);
            RoleEntity roleEntity = this.roleService.GetRoleById(1);
            Assert.AreEqual(role.Name, roleEntity.RoleName);
        }

        [TestMethod]
        public void DeleteRoleTest()
        {
            this.unitOfWork.RoleRepository.Delete(1);
            this.roleService.DeleteRole(2);
            Assert.AreEqual(roles.Count, 0);
        }

        [TestMethod]
        public void SaveRoleTest()
        {
            Role rolenew = new Role();
            rolenew.Name = "New Role";
            this.unitOfWork.RoleRepository.Insert(rolenew);
            RoleEntity getRole = this.roleService.GetRoleById(3);
            Assert.AreEqual(rolenew.Name, getRole.RoleName);
        }

        [TestMethod]
        public void GetAllRoleTest()
        {
            List<GetAllRoles_Result> roleList = this.unitOfWork.DailyStatusRepository.GetAllRoles(1, 10, "Name", "ASC", "", true);
            List<RoleListEntity> roleListEntity = this.roleService.GetAllRole("", true, 20, 10, "ASC", "Name");
            Assert.AreEqual(roleList.Count, roleListEntity.Count);
        }
    }
}
