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
    .AddAntiforgery()
    .AddRazorComponents().AddInteractiveServerComponents();

var app = builder.Build();

app
    .UseCompiledHashCacheBuster()
    .UseStaticFiles()
    .UseAntiforgery();

app.MapUsersWithStorage();

app.MapStaticAssets();
app.MapSheets();
app.MapPwaInformationFromAppSettings();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();//.AddAdditionalAssemblies(AdditionalComponents.Assembly);

app.Run();