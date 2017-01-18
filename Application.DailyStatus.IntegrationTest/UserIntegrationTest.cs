using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Net.Http;
using System.Collections.Generic;
using Application.DailyStatus.MockData;
using Application.DailyStatus.DataAccessEntities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Application.DailyStatus.BusinessEntities;
using System.Net;

namespace Application.DailyStatus.IntegrationTest
{
    [TestClass]
    public class UserIntegrationTest
    {
        private string serviceBaseURL = ConfigurationManager.AppSettings["BaseUrl"];
        private HttpResponseMessage response;
        private User loginUser;

        [TestInitialize]
        public void Setup()
        {
            loginUser = DataInitializer.GetLoginUser();
        }

        [TestMethod]
        public void SecurityTokenTest()
        {
            string token = getUserToken();
            Assert.IsNotNull(token);
        }

        [TestMethod]
        public void GetUserByIdTest()
        {
            string token = getUserToken();
            var client = new HttpClient { BaseAddress = new Uri(serviceBaseURL) };
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            response = client.GetAsync("api/v1/User/1").Result;
            var responseResult = JsonConvert.DeserializeObject<UserEntity>(response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(response.StatusCode, HttpStatusCode.OK);
        }

        private string getUserToken()
        {
            var client = new HttpClient { BaseAddress = new Uri(serviceBaseURL) };
            var content = new FormUrlEncodedContent(new[]
        {
             new KeyValuePair<string, string>("UserName", loginUser.Name),
             new KeyValuePair<string, string>("Password", loginUser.Password),
             new KeyValuePair<string, string>("grant_type", "password")
        });

            response = client.PostAsync("token", content).Result;
            JObject tokenResponse = JObject.Parse(response.Content.ReadAsStringAsync().Result);

            return tokenResponse["access_token"].ToString();
        }
    }
}
