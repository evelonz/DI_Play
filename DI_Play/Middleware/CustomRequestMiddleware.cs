using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace DI_Play.Middleware
{
    public class CustomRequestMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomRequestMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IScopedCustomRequestContextProvider factory)
        {
            var service = new MyScopedService();
            service.ScopedMesssage = $"MyScopedMessage! called from {context.Request.Host.Host}.";
            factory.Service = service;

            // Call the next delegate/middleware in the pipeline
            await _next(context);
        }
    }

}
