using DI_Play.Configuration;

namespace DI_Play.Services
{
    internal class ScopedService : BaseService, IScopedService
    {
        private readonly ServiceConfiguration _config;

        public override string GetMessage() => _config.MessagePrefix + " From Scoped, " + base.GetMessage();

        public ScopedService(ServiceConfiguration config)
        {
            _config = config;
        }
    }
}
