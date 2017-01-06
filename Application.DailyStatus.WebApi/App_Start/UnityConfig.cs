using Application.DailyStatus.BusinessCommon;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Unity.WebApi;

namespace Application.DailyStatus.WebApi
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = UnityContainerHelper.BuildUnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}