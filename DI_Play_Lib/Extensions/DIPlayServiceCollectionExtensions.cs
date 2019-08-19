﻿using DI_Play_Lib.Configuration;
using DI_Play_Lib.Services.InternalySetUpServices;
using Microsoft.Extensions.DependencyInjection;

namespace DI_Play_Lib.Extensions
{
    public static class DIPlayServiceCollectionExtensions
    {
        public static IServiceCollection AddDIPlayService(this IServiceCollection services)
        {
            services.AddScoped<ISimpleLibService, SimpleLibService>();
            services.AddSingleton<IInternalServiceConfiguration, InternalServiceConfiguration>();
            services.AddScoped<IConfigurableLibService, ConfigurableLibService>();
            return services;
        }
    }
}
