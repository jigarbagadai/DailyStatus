using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.DailyStatus.BusinessInterface;
using Application.DailyStatus.DataAccessInterface;
using Application.DailyStatus.DataAccessEntities;
using System.Net.Http;
using System.Configuration;
using Moq;
using Application.DailyStatus.BusinessService;
using Application.DailyStatus.MockData;
using Application.DailyStatus.WebApi.Controllers;
using System.Web.Http.Hosting;
using System.Web.Http;
using Newtonsoft.Json;
using Application.DailyStatus.BusinessEntities;
using System.Net;
using Application.DailyStatus.BusinessCommon;
using Application.DailyStatus.WebApi.Common;

namespace Application.DailyStatus.WebAPITest
{
    /// <summary>
    /// Summary description for UserControllerTest
    /// </summary>
    [TestClass]
    public class UserControllerTest
    {
        private IUserServices userService;
        private IUnitOfWork unitOfWork;
        private List<User> users;
        private GenericRepository<User> userRepository;
        private DatabaseConnection dbEntities;
        private HttpClient client;
        private DailyStatusActionResult response;
        private string serviceBaseURL = ConfigurationManager.AppSettings["BaseUrl"];

        [TestInitialize]
        public void Setup()
        {
            users = DataInitializer.GetUsers();
            dbEntities = new Mock<DatabaseConnection>().Object;
            userRepository = SetUpUserRepository(); ;
            var mockUnitOfWork = new Mock<IUnitOfWork>();
            mockUnitOfWork.SetupGet(s => s.UserRepository).Returns(userRepository);
            unitOfWork = mockUnitOfWork.Object;
            userService = new UserServices(unitOfWork);
            client = new HttpClient { BaseAddress = new Uri(serviceBaseURL) };
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
            UserController userController = new UserController(userService);
            userController.Request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(serviceBaseURL + "api/v1/1")
            };

            userController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, new HttpConfiguration());
            response = userController.Get(1);
            Assert.AreEqual(response.Result.ResponseStatus,ResponseStatus.Sucess);
            Assert.IsNotNull(response.Result.ResponseData);
        }
    }
}
