using Application.DailyStatus.DataAccess;
using Application.DailyStatus.DataAccessInterface;
using Application.DailyStatus.Resolver;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.DataAccessCommon
{
    [Export(typeof(IComponent))]
    public class DependencyResolver : IComponent
    {
        public void SetUp(IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<DataAccessInterface.IUnitOfWork, DataAccess.UnitOfWork>();
        }
    }
}
