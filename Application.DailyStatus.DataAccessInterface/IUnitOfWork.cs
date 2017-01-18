using Application.DailyStatus.DataAccessEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.DataAccessInterface
{
    public interface IUnitOfWork
    {
        GenericRepository<User> UserRepository { get; }

        void Save();
    }
}
