using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.BusinessEntities
{
    public class UserEntity: BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LoginId { get; set; }
        public string MobileNumber { get; set; }
        public string UserRole { get; set; }
        public string TimeZone { get; set; }
    }
}
