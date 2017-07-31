using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Modules;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Orchard.Environment.Shell;

namespace Module2
{
    public class Startup : StartupBase
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public override void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IRouteBuilder routes, IServiceProvider serviceProvider)
        {
            app.Map("/hello", branch => 
                branch.Run(context => context.Response.WriteAsync("Hello World"))
            );


            app.Map("/info", branch =>
            {
                branch.Run(context =>
                {
                    var shellSettings = context.RequestServices.GetRequiredService<ShellSettings>();
                    return context.Response.WriteAsync($"Request from tenant: {shellSettings.Name}");
                });
            });
        }
    }
}
