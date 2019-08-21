using DI_Play_Lib.Configuration;
using DI_Play_Lib.Services.InternalySetUpServices;
using DI_Play_Lib.Services.InternalySetUpServices.BuildableService;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DI_Play_Lib.Extensions
{
    public static class DIPlayServiceCollectionExtensions
    {
        public static IServiceCollection AddDIPlayService(this IServiceCollection services)
        {
            services.AddScoped<ISimpleLibService, SimpleLibService>();
            services.AddSingleton<IInternalServiceConfiguration, InternalServiceConfiguration>();
            services.AddSingleton<IConfigurableLibService, ConfigurableLibService>();
            services.AddSingleton<IMultipleServices, MultipleServicesOne>();
            services.AddSingleton<IMultipleServices, MultipleServicesTwo>();
            return services;
        }

        public static IBuildableServiceBuilder AddBuildableService(this IServiceCollection services)
        {
            services.AddTransient<IBuildableService, BuildableService>();
            return new BuildableServiceBuilder(services);
        }

        public static IServiceCollection AddBuildableService(this IServiceCollection services, Action<IBuildableServiceBuilder> builderFunction)
        {
            services.AddTransient<IBuildableService, BuildableService>();
            var builder = new BuildableServiceBuilder(services);
            builderFunction.Invoke(builder);

            return services;
        }
    }
}
