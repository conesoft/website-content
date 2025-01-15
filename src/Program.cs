using Conesoft.Hosting;
using Conesoft.PwaGenerator;
using Conesoft.Website.CDN.Components;
using Conesoft.Website.CDN.Features.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddHostConfigurationFiles()
    .AddHostEnvironmentInfo()
    .AddLoggingService()
    .AddUsersWithStorage()
    .AddSheets()
    ;

builder.Services
    .AddCompiledHashCacheBuster()
    .AddHttpClient()
    .AddRazorComponents().AddInteractiveServerComponents()
    ;

var app = builder.Build();

app.MapPwaInformationFromAppSettings();
app.MapUsersWithStorage();
app.MapStaticAssets();
app.MapSheets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();