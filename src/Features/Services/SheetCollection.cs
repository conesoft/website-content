namespace Conesoft.Website.CDN.Features.Services;

public class SheetCollection()
{
    public Sheet[] Sheets { get; private set; } = Directory.GetFiles("wwwroot", "*.css", SearchOption.TopDirectoryOnly).Select(f => new Sheet(Path.GetFileName(f))).ToArray();
}