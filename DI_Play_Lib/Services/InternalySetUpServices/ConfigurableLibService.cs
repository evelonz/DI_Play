using DI_Play_Lib.Configuration;

namespace DI_Play_Lib.Services.InternalySetUpServices
{
    internal class ConfigurableLibService : BaseService, IConfigurableLibService
    {
        private readonly IInternalServiceConfiguration _config;

        public override string GetMessage() => _config.MessagePrefix + " From internal config impl., " + base.GetMessage();

        public ConfigurableLibService(IInternalServiceConfiguration config)
        {
            _config = config;
        }
    }
}
