using DI_Play_Lib.Services;
using DI_Play_Lib.Services.InternalySetUpServices;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DI_Play_Console.Services
{
    internal class TestBasicDI
    {
        internal static void ServiceScopes(ServiceProvider serviceProvider)
        {
            while (true)
            {
                UserServices(serviceProvider);

                Console.WriteLine("Press any other key to run again and see which services gets a new instance. Press q to exit.");
                var key = Console.ReadKey();
                Console.WriteLine("");
                if (key.KeyChar == 'q') break;
            }
        }

        private static void UserServices(ServiceProvider serviceProvider)
        {
            Utility.CallServiceSimple<ITransientService>(serviceProvider);
            Utility.CallServiceSimple<ITransientService>(serviceProvider);

            using (var serviceScope = serviceProvider.CreateScope())
            {
                Utility.CallServiceSimple<IScopedService>(serviceScope.ServiceProvider);
                Utility.CallServiceSimple<IScopedService>(serviceScope.ServiceProvider);
            }
            using (var serviceScope = serviceProvider.CreateScope())
            {
                Utility.CallServiceSimple<IScopedService>(serviceScope.ServiceProvider);
            }

            Utility.CallServiceSimple<ISingletonService>(serviceProvider);
            Utility.CallServiceSimple<ISingletonService>(serviceProvider);
        }

        /// <summary>
        /// Gets an IEnumerable of registered services on a single interface.
        /// It seems that the default when a single service on the interface is requested is
        /// that the last registered implementation is returned.
        /// </summary>
        internal static void MultipleServicesOnSingleInterface(ServiceProvider serviceProvider)
        {
            Utility.CallIEnumerableServiceDetailed<IMultipleServices>(serviceProvider);
        }
    }
}
