using System.Linq;
using System.Web.Mvc;

using Unity.AspNet.Mvc;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BNP.Web.UnityMvcActivator), nameof(BNP.Web.UnityMvcActivator.Start))]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(BNP.Web.UnityMvcActivator), nameof(BNP.Web.UnityMvcActivator.Shutdown))]

namespace BNP.Web
{
    public static class UnityMvcActivator
    {
        public static void Start()
        {
            UnityConfig.RegisterComponents();

            FilterProviders.Providers.Remove(
                FilterProviders.Providers.OfType<FilterAttributeFilterProvider>().First());
            FilterProviders.Providers.Add(new UnityFilterAttributeFilterProvider(UnityConfig.Container));

            DependencyResolver.SetResolver(new UnityDependencyResolver(UnityConfig.Container));
        }

        public static void Shutdown()
        {
            UnityConfig.Container?.Dispose();
        }
    }
}