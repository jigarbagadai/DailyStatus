using Application.DailyStatus.BusinessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DailyStatus.BusinessEntities;
using Application.DailyStatus.DataModel;
using AutoMapper;

namespace Application.DailyStatus.BusinessService
{
    public class UserServices : BaseService, IUserServices
    {
        public UserEntity GetUserById(int userId)
        {
            User user = this.unitOfWork.UserRepository.GetByID(userId);
            if (user != null)
            {
                UserEntity userEntity = new UserEntity();
                userEntity = Mapper.Map<User, UserEntity>(user);
                return userEntity;
            }

            return null;
        }
    }
}
