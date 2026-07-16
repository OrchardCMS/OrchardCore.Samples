using OCBlazorLib;
using OrchardCore.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseNLogHost();

builder.Services
    .AddOrchardCms()
    .ConfigureServices(services => {
        services.AddRazorComponents()
       .AddInteractiveServerComponents()
       ;

    })
    .Configure((app, routes, services) => {
        app.UseStaticFiles();
        app.UseAntiforgery();
        routes.MapRazorComponents<App>()
            .AddInteractiveServerRenderMode()
       ;
    })
;

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseOrchardCore();

app.Run();
