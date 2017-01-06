using Application.DailyStatus.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.BusinessService
{
    public class BaseService
    {
        protected readonly UnitOfWork unitOfWork;

        public BaseService(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
