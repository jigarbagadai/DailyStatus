using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.BusinessEntities
{
    public class RoleListEntity : BaseEntity
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public int TotalRows { get; set; }
    }
}
