using DI_Play_Lib.Extensions;
using DI_Play_Lib.Services.InternalySetUpServices.BuildableService;
using Microsoft.Extensions.DependencyInjection;
using ServiceUtility = DI_Play_Console.Services.Utility;

namespace DI_Play_Console.Services
{
    internal static class TestBuildableServices
    {
        internal static void UsingBuilder(IServiceCollection services)
        {
            var builder = services.AddBuildableService();
            builder.RemovePrefixMessage();

            var provider = services.BuildServiceProvider();
            ServiceUtility.CallServiceSimple<IBuildableService>(provider);

            builder.AddPrefixMessage("Test With Prefix. ");
            provider = services.BuildServiceProvider();
            ServiceUtility.CallServiceSimple<IBuildableService>(provider);
        }

        internal static void UsingAction(IServiceCollection services)
        {
            ServiceUtility.RemoveService<IBuildableService>(services);
            services.AddBuildableService((config) => {
                config.RemovePrefixMessage();
            });
            var provider = services.BuildServiceProvider();
            ServiceUtility.CallServiceSimple<IBuildableService>(provider);

            ServiceUtility.RemoveService<IBuildableService>(services);
            services.AddBuildableService((config) => {
                config.AddPrefixMessage("Test with new Prefix. ");
            });

            provider = services.BuildServiceProvider();
            ServiceUtility.CallServiceSimple<IBuildableService>(provider);
        }
    }
}
