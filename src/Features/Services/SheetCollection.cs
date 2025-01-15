namespace Conesoft.Website.CDN.Features.Services;

public class SheetCollection()
{
    static readonly Files.Directory root = Files.Directory.From("wwwroot");

    public Sheet[] Sheets { get; private set; } =
        root
        .FilteredFiles("*.css", allDirectories: false)
        .Where(f => (root / "styles" / f.NameWithoutExtension).Exists)
        .Select(f => new Sheet(f.Name))
        .ToArray();
}