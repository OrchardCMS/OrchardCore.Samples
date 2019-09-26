using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
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
        }
    }
}
