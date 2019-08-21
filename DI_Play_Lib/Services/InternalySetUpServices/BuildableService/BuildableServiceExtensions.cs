using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DI_Play_Lib.Services.InternalySetUpServices.BuildableService
{
    public static class BuildableServiceExtensions
    {
        public static IBuildableServiceBuilder AddPrefixMessage(this IBuildableServiceBuilder builder, string message)
        {
            builder.Services.TryAddSingleton<IBuildableServicePrefixMessage>(new BuildableServicePrefixMessage(message));
            return builder;
        }

        public static IBuildableServiceBuilder RemovePrefixMessage(this IBuildableServiceBuilder builder)
        {
            builder.Services.RemoveAll<IBuildableServicePrefixMessage>();
            return builder;
        }
    }

    internal interface IBuildableServicePrefixMessage
    {
        string PrefixMessage { get; }
    }

    internal class BuildableServicePrefixMessage : IBuildableServicePrefixMessage
    {
        public string PrefixMessage { get; }

        public BuildableServicePrefixMessage(string message)
        {
            PrefixMessage = message;
        }
    }
}
