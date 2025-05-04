using System.Security.Cryptography;

namespace Conesoft.Website.Content.Features.Services;

public record Sheet(string Filename)
{
    public string Url => $"https://content.conesoft.net/{Filename}";
    public string Path => $"wwwroot/{Filename}";
    public string Category => Filename.EndsWith(".min.css") ? "minified" : "uncompressed";
    public string Md5 { get; } = CalculateMd5(Filename);

    private static string CalculateMd5(string Filename)
    {
        using var md5 = MD5.Create();
        using var stream = File.OpenRead($"wwwroot/{Filename}");
        return Convert.ToHexStringLower(md5.ComputeHash(stream));
    }
}