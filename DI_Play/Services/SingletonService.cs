namespace DI_Play.Services
{
    internal class SingletonService : BaseService, ISingletonService
    {
        public override string GetMessage() => "From Singleton, " + base.GetMessage();
    }
}
