using Application.DailyStatus.BusinessInterface;
using Application.DailyStatus.BusinessService;
using Application.DailyStatus.DataAccess;
using Application.DailyStatus.Resolver;
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
            RegisterTypes(container);
            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            //Component initialization via MEF
            ComponentLoader.LoadContainer(container, ".\\bin", "Application.DailyStatus.*.dll");
        }
    }
}
