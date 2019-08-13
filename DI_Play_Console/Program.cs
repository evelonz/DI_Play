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
            var serviceProvider = new ServiceCollection()
                .AddTransient<ITransientService, TransientService>()
                //.AddScoped<IScopedService, ScopedService>()
                .AddSingleton<ISingletonService, SingletonService>()
                .BuildServiceProvider();

            while (true)
            {
                UserServices(serviceProvider);

                System.Console.WriteLine("Press q to exit. Press any other key to run again.");
                var key = System.Console.ReadKey();
                if (key.KeyChar == 'q') break;
            }

        }

        private static void UserServices(ServiceProvider serviceProvider)
        {
            // Retrive services.
            var transientService = (ITransientService)serviceProvider.GetService(typeof(ITransientService));
            var transient2 = (ITransientService)serviceProvider.GetService(typeof(ITransientService));
            //var scopedService = (IScopedService)serviceProvider.GetService(typeof(IScopedService));
            //var scoped2 = (IScopedService)serviceProvider.GetService(typeof(IScopedService));
            var singletonService = (ISingletonService)serviceProvider.GetService(typeof(ISingletonService));
            var singleton2 = (ISingletonService)serviceProvider.GetService(typeof(ISingletonService));

            // Call retrived services.
            System.Console.WriteLine(transientService.GetMessage());
            System.Console.WriteLine(transient2.GetMessage());
            //System.Console.WriteLine(scopedService.GetMessage());
            //System.Console.WriteLine(scoped2.GetMessage());
            System.Console.WriteLine(singletonService.GetMessage());
            System.Console.WriteLine(singleton2.GetMessage());
        }
    }
}
