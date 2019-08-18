namespace DI_Play_Lib.Services.InternalySetUpServices
{
    internal class SimpleLibService : BaseService, ISimpleLibService
    {
        public override string GetMessage() => "From Internal lib implementation, " + base.GetMessage();
    }
}
