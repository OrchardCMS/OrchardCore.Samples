using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ModularApplication
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Module1 needs this AddMvc call and the OrchardCore.Application.Mvc.Targets PackageReference.
            // Module2 only needs the OrchardCore.Application.Targets PackageReference and of course AddOrchardCore and UseOrchardCore.

            services.AddOrchardCore()
                .AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync($"Hello from ModularApplication! " +
                        $"Get the weather from Module1 at {context.Request.Scheme}://{context.Request.Host}/WeatherForecast " +
                        $"or say hello to Module2 at {context.Request.Scheme}://{context.Request.Host}/Module2/hello");
                });
            });

            app.UseOrchardCore();
        }
    }
}
