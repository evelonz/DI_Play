namespace DI_Play_Lib.Services.InternalySetUpServices
{
    internal class MultipleServicesTwo : BaseService, IMultipleServices
    {
        public override string GetMessage() => "From Multiple Services Two, " + base.GetMessage();
    }
}
