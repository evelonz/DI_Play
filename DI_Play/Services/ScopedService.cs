namespace DI_Play.Services
{
    internal class ScopedService : BaseService, IScopedService
    {
        public override string GetMessage() => "From Scoped, " + base.GetMessage();
    }
}
