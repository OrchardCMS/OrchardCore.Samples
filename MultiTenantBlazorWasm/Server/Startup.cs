using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace MultiTenantBlazorWasm.Server
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddOrchardCore()
                .AddMvc()
                .WithTenants()
                .Configure( (app,routes,svc) =>
                {
                    app.UseBlazorFrameworkFiles();
                    app.UseStaticFiles();
                    routes.MapFallbackToFile("index.html");
                })
                ;
        }
        
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOrchardCore();
        }
    }
}
