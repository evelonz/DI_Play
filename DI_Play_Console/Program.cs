using System;
using System.Linq;
using DI_Play_Lib.Configuration;
using DI_Play_Lib.Extensions;
using DI_Play_Lib.Services;
using DI_Play_Lib.Services.InternalySetUpServices;
using Microsoft.Extensions.DependencyInjection;

namespace DI_Play_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // Base code taken from this blog post: https://andrewlock.net/using-dependency-injection-in-a-net-core-console-application/

            // setup DI.
            var serviceCollection = new ServiceCollection()
                .AddTransient<ITransientService, TransientService>()
                .AddSingleton(new ServiceConfiguration())
                .AddScoped<IScopedService, ScopedService>()
                .AddSingleton<ISingletonService, SingletonService>()
                .AddDIPlayService();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Select test to run:");
                Console.WriteLine("1: Test Service Scopes");
                Console.WriteLine("2: Test Library Service");
                Console.WriteLine("3/4: Test Library Service with {lib/app} config");
                Console.WriteLine("5: Test Multiple Services On Single Interface");

                var testKey = Console.ReadKey().KeyChar;
                Console.WriteLine("");
                switch (testKey)
                {
                    case '1':
                        TestServiceScopes(serviceProvider);
                        break;
                    case '2':
                        TestLibraryService(serviceProvider);
                        break;
                    case '3':
                        TestOverridingLibraryService(serviceCollection, false);
                        break;
                    case '4':
                        TestOverridingLibraryService(serviceCollection, true);
                        break;
                    case '5':
                        TestMultipleServicesOnSingleInterface(serviceProvider);
                        break;
                    default:
                        Console.WriteLine("Incorrect option selected!");
                        break;
                }

                Console.WriteLine("Press q to exit program. Press any other key to select a new test.");
                if (Console.ReadKey().KeyChar == 'q') break;
            }

        }

        private static void TestLibraryService(ServiceProvider serviceProvider)
        {
            CallServiceDetailed<ISimpleLibService>(serviceProvider);
        }

        private static void TestOverridingLibraryService(IServiceCollection services, bool useAppConfig)
        {
            RemoveService<IInternalServiceConfiguration>(services);

            // This is only supposed to be done during setup. We do it here at run time merely as an example of how to do it.
            if (useAppConfig)
                services.AddSingleton<IInternalServiceConfiguration, AppConfig>();
            else
                services.AddSingleton<IInternalServiceConfiguration, InternalServiceConfiguration>();

            var serviceProvider = services.BuildServiceProvider();

            CallServiceDetailed<IConfigurableLibService>(serviceProvider);
        }

        public class AppConfig : IInternalServiceConfiguration
        {
            public string MessagePrefix => "App config!";
        }

        private static void CallServiceDetailed<T>(ServiceProvider serviceProvider) where T : IBaseService
        {
            Console.WriteLine($"Test call to service of type {typeof(T).Name}.");
            var service = serviceProvider.GetService<T>();
            Console.WriteLine($"Got implementation {service.GetType().Name}.");
            Console.WriteLine(service.GetMessage() + Environment.NewLine);
        }

        private static void RemoveService<T>(IServiceCollection services)
        {
            var libconfig = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(T));
            services.Remove(libconfig);
        }

        private static void TestServiceScopes(ServiceProvider serviceProvider)
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
            CallServiceSimple<ITransientService>(serviceProvider);
            CallServiceSimple<ITransientService>(serviceProvider);

            using(var serviceScope = serviceProvider.CreateScope())
            {
                CallServiceSimple<IScopedService>(serviceScope.ServiceProvider);
                CallServiceSimple<IScopedService>(serviceScope.ServiceProvider);
            }
            using (var serviceScope = serviceProvider.CreateScope())
            {
                CallServiceSimple<IScopedService>(serviceScope.ServiceProvider);
            }

            CallServiceSimple<ISingletonService>(serviceProvider);
            CallServiceSimple<ISingletonService>(serviceProvider);
        }

        private static void CallServiceSimple<T>(IServiceProvider serviceProvider) where T : IBaseService
        {
            var service = (T)serviceProvider.GetService(typeof(T));
            Console.WriteLine(service.GetMessage());
        }

        /// <summary>
        /// Gets an IEnumerable of registered services on a single interface.
        /// It seems that the default when a single service on the interface is requested is
        /// that the last registered implementation is returned.
        /// </summary>
        private static void TestMultipleServicesOnSingleInterface(ServiceProvider serviceProvider)
        {
            CallIEnumerableServiceDetailed<IMultipleServices>(serviceProvider);
        }

        private static void CallIEnumerableServiceDetailed<T>(ServiceProvider serviceProvider) where T : IBaseService
        {
            Console.WriteLine($"Test call to service of type {typeof(T).Name}.");
            var services = serviceProvider.GetServices<T>();
            foreach (var service in services)
            {
                Console.WriteLine($"Got implementation {service.GetType().Name}.");
                Console.WriteLine(service.GetMessage() + Environment.NewLine);
            }
        }
    }
}
