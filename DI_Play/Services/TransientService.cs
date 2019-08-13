namespace DI_Play.Services
{
    internal class TransientService : BaseService, ITransientService
    {
        public override string GetMessage() => "From Transient, " + base.GetMessage();
    }
}
