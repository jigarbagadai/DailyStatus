using Application.DailyStatus.BusinessInterface;
using Application.DailyStatus.BusinessService;
using Application.DailyStatus.Resolver;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.BusinessCommon
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUserServices, UserServices>();

        }
    }
}
