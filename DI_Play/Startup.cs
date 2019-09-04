using DI_Play.Middleware;
using DI_Play_Lib.Configuration;
using DI_Play_Lib.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Logging;

namespace DI_Play
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            // Requires `Microsoft.Extensions.Logging`. Also added in `Main`.
            //services.AddLogging((builder) => { builder.AddConsole(); });

            // Example loading settings into a class that can be dependency injected into other classes.
            // in this example it is done without a interface, so it will inject only where the class is needed.
            var config = new ServiceConfiguration();
            Configuration.Bind("ServiceConfiguration", config);
            services.AddSingleton(config);

            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-2.2
            // Created ones each time it is requested.
            services.AddTransient<ITransientService, TransientService>();
            // Created ones per client request.
            services.AddScoped<IScopedService, ScopedService>();
            // Created ones for the lifespan of the application (created on first request).
            services.AddSingleton<ISingletonService, SingletonService>();

            services.AddScoped<IScopedCustomRequestContextProvider, MyScopedCustomRequestProvider>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMiddleware<CustomRequestMiddleware>();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
