namespace DI_Play.Middleware
{
    public class MyScopedService : ICustomRequestContext
    {
        public string ScopedMesssage { get; set; }
    }

}
