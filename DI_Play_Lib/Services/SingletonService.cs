namespace DI_Play_Lib.Services
{
    public class SingletonService : BaseService, ISingletonService
    {
        public override string GetMessage() => "From Singleton, " + base.GetMessage();
    }
}
