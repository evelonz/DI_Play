using System;
using Microsoft.Extensions.DependencyInjection;

namespace DI_Play_Lib.Services.InternalySetUpServices.BuildableService
{
    internal class BuildableServiceBuilder : IBuildableServiceBuilder
    {
        public IServiceCollection Services { get; }

        public BuildableServiceBuilder(IServiceCollection services)
        {
            Services = services;
        }
    }
}
