namespace DI_Play.Middleware
{
    public class MyScopedCustomRequestProvider : IScopedCustomRequestContextProvider
    {
        public ICustomRequestContext Service { get; set; }
    }

}
