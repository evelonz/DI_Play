using System;
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
            var serviceProvider = new ServiceCollection()
                .AddTransient<ITransientService, TransientService>()
                .AddSingleton(new ServiceConfiguration())
                .AddScoped<IScopedService, ScopedService>()
                .AddSingleton<ISingletonService, SingletonService>()
                .AddDIPlayService()
                .BuildServiceProvider();

            Console.WriteLine("Test of added library service:");
            var diPlayService = (ISimpleLibService)serviceProvider.GetService(typeof(ISimpleLibService));
            Console.WriteLine(diPlayService.GetMessage() + Environment.NewLine);

            while (true)
            {
                UserServices(serviceProvider);

                Console.WriteLine("Press q to exit. Press any other key to run again.");
                var key = Console.ReadKey();
                if (key.KeyChar == 'q') break;
            }

        }

        private static void UserServices(ServiceProvider serviceProvider)
        {
            // Retrive services.
            var transientService = (ITransientService)serviceProvider.GetService(typeof(ITransientService));
            var transient2 = (ITransientService)serviceProvider.GetService(typeof(ITransientService));
            var scopedService = (IScopedService)serviceProvider.GetService(typeof(IScopedService));
            var scoped2 = (IScopedService)serviceProvider.GetService(typeof(IScopedService));
            var singletonService = (ISingletonService)serviceProvider.GetService(typeof(ISingletonService));
            var singleton2 = (ISingletonService)serviceProvider.GetService(typeof(ISingletonService));

            // Call retrived services.
            Console.WriteLine(transientService.GetMessage());
            Console.WriteLine(transient2.GetMessage());
            Console.WriteLine(scopedService.GetMessage());
            Console.WriteLine(scoped2.GetMessage());
            Console.WriteLine(singletonService.GetMessage());
            Console.WriteLine(singleton2.GetMessage());
        }
    }
}
