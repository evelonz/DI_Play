using System;
using System.Linq;
using DI_Play_Lib.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DI_Play_Console.Services
{
    internal static class Utility
    {
        internal static void CallServiceSimple<T>(IServiceProvider serviceProvider) where T : IBaseService
        {
            var service = (T)serviceProvider.GetService(typeof(T));
            Console.WriteLine(service.GetMessage());
        }

        internal static void CallServiceDetailed<T>(ServiceProvider serviceProvider) where T : IBaseService
        {
            Console.WriteLine($"Test call to service of type {typeof(T).Name}.");
            var service = serviceProvider.GetService<T>();
            Console.WriteLine($"Got implementation {service.GetType().Name}.");
            Console.WriteLine(service.GetMessage() + Environment.NewLine);
        }

        internal static void CallIEnumerableServiceDetailed<T>(ServiceProvider serviceProvider) where T : IBaseService
        {
            Console.WriteLine($"Test call to service of type {typeof(T).Name}.");
            var services = serviceProvider.GetServices<T>();
            foreach (var service in services)
            {
                Console.WriteLine($"Got implementation {service.GetType().Name}.");
                Console.WriteLine(service.GetMessage() + Environment.NewLine);
            }
        }

        internal static void RemoveService<T>(IServiceCollection services)
        {
            var libconfig = services.FirstOrDefault(descriptor => descriptor.ServiceType == typeof(T));
            services.Remove(libconfig);
        }
    }
}
