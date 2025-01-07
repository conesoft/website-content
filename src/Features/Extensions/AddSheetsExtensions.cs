using Conesoft.Website.CDN.Features.Services;

namespace Conesoft.Website.CDN.Features.Extensions;

public static class AddSheetsExtensions
{
    public static WebApplicationBuilder AddSheets(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<SheetCollection>();
        return builder;
    }

    public static WebApplication MapSheets(this WebApplication app)
    {
        app.MapGet("/{name}.md5", (string name, SheetCollection collection) =>
        {
            if (collection.Sheets.FirstOrDefault(s => s.Filename == name) is Sheet sheet)
            {
                return Results.Text(sheet.Md5);
            }
            return Results.NotFound();
        });
        return app;
    }
}