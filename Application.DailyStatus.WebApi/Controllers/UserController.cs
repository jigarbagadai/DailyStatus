using Application.DailyStatus.BusinessEntities;
using Application.DailyStatus.BusinessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application.DailyStatus.WebApi.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserServices userService;

        public UserController(IUserServices userService)
        {
            this.userService = userService;
        }

        public HttpResponseMessage Get(int id)
        {
            UserEntity user = this.userService.GetUserById(id);
            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "User Not Exist");
            }
        }
    }
}
