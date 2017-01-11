using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.Resolver
{
    internal class RegisterComponent : IRegisterComponent
    {
        private readonly IUnityContainer container;

        public RegisterComponent(IUnityContainer container)
        {
            this.container = container;
        }

        public void RegisterType<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            if (withInterception)
            {
                //register with interception
            }
            else
            {
                this.container.RegisterType<TFrom, TTo>();
            }
        }

        public void RegisterTypeWithControlledLifeTime<TFrom, TTo>(bool withInterception = false) where TTo : TFrom
        {
            this.container.RegisterType<TFrom, TTo>(new ContainerControlledLifetimeManager());
        }
    }
}
