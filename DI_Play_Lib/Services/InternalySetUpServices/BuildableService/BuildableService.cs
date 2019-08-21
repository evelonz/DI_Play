namespace DI_Play_Lib.Services.InternalySetUpServices.BuildableService
{
    internal class BuildableService : BaseService, IBuildableService
    {
        private readonly string _prefix;
        public override string GetMessage() => _prefix + "From Buildable Service, " + base.GetMessage();

        public BuildableService(IBuildableServicePrefixMessage prefixMessage)
        {
            _prefix = prefixMessage.PrefixMessage;
        }

        public BuildableService()
        {
            _prefix = "";
        }
    }
}
