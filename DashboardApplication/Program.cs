using MudBlazor.Services;
using OrchardCore.Recipes;
using OrchardCore.ResourceManagement.TagHelpers;

var builder = WebApplication.CreateBuilder(args);

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
    });
// Fallback redirect to Admin dashboard

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddServerSideBlazor();
builder.Services.AddMudServices();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();
app.UseOrchardCore();
app.MapBlazorHub("/app/_blazor");

app.Run();
