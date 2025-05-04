using Conesoft.Hosting;
using Conesoft.PwaGenerator;
using Conesoft.Website.Content.Components;
using Conesoft.Website.Content.Features.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder
    .AddHostConfigurationFiles()
    .AddHostEnvironmentInfo()
    .AddLoggingService()
    .AddUsersWithStorage()
    .AddCompiledHashCacheBuster()
    .AddHostingDefaults()
    .AddSheets()
    ;

var app = builder.Build();

app.UseCompiledHashCacheBuster();
app.MapPwaInformationFromAppSettings();
app.MapUsersWithStorage();
app.MapStaticAssets();
app.MapSheets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();