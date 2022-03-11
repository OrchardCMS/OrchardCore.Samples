var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOrchardCore().AddMvc();

var app = builder.Build();

if (app.Environment.IsDevelopment())
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

app.Run();
