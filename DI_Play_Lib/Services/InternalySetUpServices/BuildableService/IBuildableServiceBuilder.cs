using Microsoft.Extensions.DependencyInjection;

namespace DI_Play_Lib.Services.InternalySetUpServices.BuildableService
{
    public interface IBuildableServiceBuilder
    {
        IServiceCollection Services { get; }
    }
}
