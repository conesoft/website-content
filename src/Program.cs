using Conesoft.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddHostConfigurationFiles()
    .AddHostEnvironmentInfo()
    .AddLoggingService()
    ;

builder.Services
    .AddCompiledHashCacheBuster()
    .AddCors()
    .AddRazorPages();

var app = builder.Build();

app
    .UseCompiledHashCacheBuster()
    .UseStaticFiles();

app.MapStaticAssets();
app.MapRazorPages();

app.Run();
