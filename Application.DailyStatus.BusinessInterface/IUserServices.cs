using Application.DailyStatus.BusinessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.BusinessInterface
{
    public  interface IUserServices
    {
        UserEntity GetUserById(int userId);

        UserEntity AuthenticateUser(string userName, string password);
    }
}
