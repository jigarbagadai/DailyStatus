using Application.DailyStatus.BusinessEntities;
using Application.DailyStatus.BusinessInterface;
using Application.DailyStatus.WebApi.Authorization;
using Application.DailyStatus.WebApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Application.DailyStatus.WebApi.Controllers
{
    [RoutePrefix("api/v1")]
    public class UserController : BaseController
    {
        private readonly IUserServices userService;

        public UserController(IUserServices userService)
        {
            this.userService = userService;
        }

        [DailyStatusAuthorize(Roles = "admin")]
        [Route("User/{id:int?}")]
        public DailyStatusActionResult Get(int id)
        {
            UserEntity user = this.userService.GetUserById(id);
            return user.ToApiResult();
        }
    }
}
