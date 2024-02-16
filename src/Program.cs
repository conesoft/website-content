var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddCors();
var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapRazorPages();

app.Run();
