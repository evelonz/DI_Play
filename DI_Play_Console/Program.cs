using System;
using DI_Play_Console.Services;
using DI_Play_Lib.Configuration;
using DI_Play_Lib.Extensions;
using DI_Play_Lib.Services;
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
                Console.WriteLine("6: Test Buildable Service Using Builder");
                Console.WriteLine("7: Test Buildable Service Using Action");

                var testKey = Console.ReadKey().KeyChar;
                Console.WriteLine("");
                switch (testKey)
                {
                    case '1':
                        TestBasicDI.ServiceScopes(serviceProvider);
                        break;
                    case '2':
                        TestLibraryService.Simple(serviceProvider);
                        break;
                    case '3':
                        TestLibraryService.OverridingLibraryServiceConfig(serviceCollection, false);
                        break;
                    case '4':
                        TestLibraryService.OverridingLibraryServiceConfig(serviceCollection, true);
                        break;
                    case '5':
                        TestBasicDI.MultipleServicesOnSingleInterface(serviceProvider);
                        break;
                    case '6':
                        TestBuildableServices.UsingBuilder(serviceCollection);
                        break;
                    case '7':
                        TestBuildableServices.UsingAction(serviceCollection);
                        break;
                    default:
                        Console.WriteLine("Incorrect option selected!");
                        break;
                }

                Console.WriteLine("Press q to exit program. Press any other key to select a new test.");
                if (Console.ReadKey().KeyChar == 'q') break;
            }

        }

    }
}
