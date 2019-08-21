using DI_Play_Lib.Configuration;
using DI_Play_Lib.Services.InternalySetUpServices;
using Microsoft.Extensions.DependencyInjection;

namespace DI_Play_Console.Services
{
    internal class TestLibraryService
    {
        internal static void Simple(ServiceProvider serviceProvider)
        {
            Utility.CallServiceDetailed<ISimpleLibService>(serviceProvider);
        }

        internal static void OverridingLibraryServiceConfig(IServiceCollection services, bool useAppConfig)
        {
            Utility.RemoveService<IInternalServiceConfiguration>(services);

            // This is only supposed to be done during setup. We do it here at run time merely as an example of how to do it.
            if (useAppConfig)
                services.AddSingleton<IInternalServiceConfiguration, AppConfig>();
            else
                services.AddSingleton<IInternalServiceConfiguration, InternalServiceConfiguration>();

            var serviceProvider = services.BuildServiceProvider();

            Utility.CallServiceDetailed<IConfigurableLibService>(serviceProvider);
        }

        public class AppConfig : IInternalServiceConfiguration
        {
            public string MessagePrefix => "App config!";
        }
    }
}
