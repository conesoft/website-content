using Conesoft.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddCompiledHashCacheBuster()
    .AddPeriodicGarbageCollection(TimeSpan.FromMinutes(5))
    .AddCors()
    .AddRazorPages();

var app = builder.Build();

app
    .UseCompiledHashCacheBuster()
    .UseStaticFiles();

app.MapStaticAssets();
app.MapRazorPages();

app.Run();
