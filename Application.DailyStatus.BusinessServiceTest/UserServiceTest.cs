using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.DailyStatus.BusinessInterface;
using Application.DailyStatus.DataAccessInterface;
using Application.DailyStatus.DataAccessEntities;
using Application.DailyStatus.MockData;
using Moq;
using Application.DailyStatus.BusinessService;
using System.Collections.Generic;
using Application.DailyStatus.BusinessEntities;
using Application.DailyStatus.BusinessCommon;

namespace Application.DailyStatus.BusinessServiceTest
{
    [TestClass]
    public class UserServiceTest
    {
        private IUserServices userService;
        private IUnitOfWork unitOfWork;
        private List<User> users;
        private GenericRepository<User> userRepository;
        private DatabaseConnection dbEntities;

        [TestInitialize]
        public void Setup()
        {
            users = DataInitializer.GetUsers();
            dbEntities = new Mock<DatabaseConnection>().Object;
            userRepository = SetUpUserRepository();
            var mokcunitOfWork = new Mock<IUnitOfWork>();
            mokcunitOfWork.SetupGet(s => s.UserRepository).Returns(userRepository);
            unitOfWork = mokcunitOfWork.Object;
            userService = new UserServices(unitOfWork);
            MapperConfiguration.IntlializeMapperConfiguration();
        }

        private GenericRepository<User> SetUpUserRepository()
        {
            var mockRepo = new Mock<GenericRepository<User>>(MockBehavior.Default, dbEntities);
            mockRepo.Setup(p => p.GetByID(It.IsAny<int>())).Returns(new Func<int, User>(id => users.Find(p => p.Id.Equals(id))));
            return mockRepo.Object;
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            User user = this.unitOfWork.UserRepository.GetByID(1);
            UserEntity userEntity = this.userService.GetUserById(1);
            Assert.AreEqual(user.Name, userEntity.UserName);
        }
    }
}
