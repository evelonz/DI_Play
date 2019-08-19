namespace DI_Play_Lib.Services.InternalySetUpServices
{
    internal class MultipleServicesOne : BaseService, IMultipleServices
    {
        public override string GetMessage() => "From Multiple Services One, " + base.GetMessage();
    }
}
