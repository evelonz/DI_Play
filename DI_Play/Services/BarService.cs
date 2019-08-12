namespace DI_Play.Services
{
    internal class BarService : IBarService
    {
        public string GetBar() => $"String from {this.GetType().Name}!";
    }
}
