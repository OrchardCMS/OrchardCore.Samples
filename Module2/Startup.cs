using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using OrchardCore.Environment.Shell;
using System;

namespace Module2
{
    public class Startup
    {
        public void Configure(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/Module2/hello", async context =>
            {
                await context.Response.WriteAsync("Hello from Module2!");
            });

            endpoints.MapGet("/info", async context =>
            {
                var shellSettings = context.RequestServices.GetRequiredService<ShellSettings>();
                await context.Response.WriteAsync($"Request from tenant: {shellSettings.Name}");
            });
        }
    }
}
