using Application.DailyStatus.BusinessInterface;
using Application.DailyStatus.BusinessService;
using Application.DailyStatus.Repository;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.BusinessCommon
{
    public static class UnityContainerHelper
    {
        public static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IUserServices, UserServices>().RegisterType<UnitOfWork>(new HierarchicalLifetimeManager());

            return container;
        }
    }
}
