using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Logging;

namespace DI_Play
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                // . Also added in `Startup`.
                //.ConfigureLogging((hostingContext, logging) =>
                //{
                //    // Requires `using Microsoft.Extensions.Logging;`
                //    logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                //    //logging.ClearProviders();
                //    logging.AddConsole();
                //    logging.AddDebug();
                //    logging.AddEventSourceLogger();
                //})
                .UseStartup<Startup>();
    }
}
