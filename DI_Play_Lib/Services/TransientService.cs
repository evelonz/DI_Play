namespace DI_Play_Lib.Services
{
    public class TransientService : BaseService, ITransientService
    {
        public override string GetMessage() => "From Transient, " + base.GetMessage();
    }
}
