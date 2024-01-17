using DashboardApplication.Controllers;
using OrchardCore.Mvc.Core.Utilities;
using OrchardCore.Recipes;
using OrchardCore.ResourceManagement.TagHelpers;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddOrchardCore()
    .AddCommands()
    .AddSecurity()
    .AddMvc()
    .AddIdGeneration()
    .AddEmailAddressValidator()
    .AddSetupFeatures("OrchardCore.Setup")
    .AddDataAccess()
    .AddDataStorage()
    .AddBackgroundService()
    .AddScripting()

    .AddTheming()
    //.AddLiquidViews()
    .AddCaching()
    .ConfigureServices(services => services
        .AddRecipes())

    // OrchardCoreBuilder is not available in OrchardCore.ResourceManagement as it has to
    // remain independent from OrchardCore.
    .ConfigureServices(s =>
    {
        s.AddResourceManagement();

        s.AddTagHelpers<LinkTagHelper>();
        s.AddTagHelpers<MetaTagHelper>();
        s.AddTagHelpers<ResourcesTagHelper>();
        s.AddTagHelpers<ScriptTagHelper>();
        s.AddTagHelpers<StyleTagHelper>();
    })

    .Configure((app, routes, services) =>
    {
        routes.MapControllerRoute(
            name: "home",
            pattern: "/",
            defaults: new { controller = typeof(HomeController).ControllerName(), action = nameof(HomeController.Index), area = "DashboardApplication" });
    });

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
