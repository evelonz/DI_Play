namespace DI_Play.Middleware
{
    public interface IScopedCustomRequestContextProvider
    {
        ICustomRequestContext Service { get; set; }
    }

}
