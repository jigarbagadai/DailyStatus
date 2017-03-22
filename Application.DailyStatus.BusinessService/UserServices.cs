using Application.DailyStatus.BusinessInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.DailyStatus.BusinessEntities;
using Application.DailyStatus.DataAccessEntities;
using AutoMapper;
using Application.DailyStatus.DataAccessInterface;
using Application.DailyStatus.DataAccess;

namespace Application.DailyStatus.BusinessService
{
    public class UserServices : BaseService, IUserServices
    {
        public UserServices(IUnitOfWork unitOfWork) : base(unitOfWork)
        {

        }

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

        public UserEntity AuthenticateUser(string userName, string password)
        {
            User user = this.unitOfWork.UserRepository.Get(m => m.LoginId == userName && m.Password == password);
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
