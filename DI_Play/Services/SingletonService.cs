namespace DI_Play.Services
{
    internal class SingletonService : ISingletonService
    {
        public string GetMessage() => "Singletons rule!";
    }
}
