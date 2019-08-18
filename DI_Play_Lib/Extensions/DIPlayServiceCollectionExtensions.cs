using DI_Play_Lib.Services.InternalySetUpServices;
using Microsoft.Extensions.DependencyInjection;

namespace DI_Play_Lib.Extensions
{
    public static class DIPlayServiceCollectionExtensions
    {
        public static IServiceCollection AddDIPlayService(this IServiceCollection services)
        {
            services.AddScoped<ISimpleLibService, SimpleLibService>();
            return services;
        }
    }
}
