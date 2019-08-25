using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace DI_Play.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _next;

        public TestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IMyScopedServiceFactory factory, IServiceCollection serv)
        {
            var service = new MyScopedService();
            service.ScopedMesssage = "MyScopedMessage!";
            factory.Service = service;
            // Call the next delegate/middleware in the pipeline

            await _next(context);
        }
    }

    public interface IMyScopedServiceFactory
    {
        IMyScopedService Service { get; set; }
    }

    public class MyScopedServiceFactory : IMyScopedServiceFactory
    {
        public IMyScopedService Service { get; set; }
    }

    public interface IMyScopedService
    {
        string ScopedMesssage { get; set; }
    }

    public class MyScopedService : IMyScopedService
    {
        public string ScopedMesssage { get; set; }
    }
}
