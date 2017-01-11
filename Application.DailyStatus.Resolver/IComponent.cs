using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.Resolver
{
    public interface IComponent
    {
        void SetUp(IRegisterComponent registerComponent);
    }
}
