namespace DI_Play_Lib.Services
{
    public class BaseService : IBaseService
    {
        private readonly System.Guid MyGuid;

        public BaseService() => MyGuid = System.Guid.NewGuid();

        public virtual string GetMessage() => $"Guid: {MyGuid}";
    }
}
