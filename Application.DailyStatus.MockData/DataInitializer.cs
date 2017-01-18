using Application.DailyStatus.DataAccessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.MockData
{
    public class DataInitializer
    {
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            User user = new User();
            user.Id = 1;
            user.Name = "Jigar 1";
            users.Add(user);

            user = new User();
            user.Id = 2;
            user.Name = "Jigar 2";
            users.Add(user);

            return users;
        }

        public static User GetLoginUser()
        {
            User user = new User();
            user.Id = 3;
            user.Name = "admin";
            user.Password = "admin";

            return user;
        }
    }
}
