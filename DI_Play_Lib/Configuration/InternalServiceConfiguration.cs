namespace DI_Play_Lib.Configuration
{
    /// <summary>
    /// Default implementation of <see cref="IInternalServiceConfiguration"/>.
    /// </summary>
    public class InternalServiceConfiguration : IInternalServiceConfiguration
    {
        public string MessagePrefix => "Internal config.";
    }
}
