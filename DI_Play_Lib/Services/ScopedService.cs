using DI_Play_Lib.Configuration;

namespace DI_Play_Lib.Services
{
    public class ScopedService : BaseService, IScopedService
    {
        private readonly ServiceConfiguration _config;

        public override string GetMessage() => _config.MessagePrefix + " From Scoped, " + base.GetMessage();

        public ScopedService(ServiceConfiguration config)
        {
            _config = config;
        }
    }
}
